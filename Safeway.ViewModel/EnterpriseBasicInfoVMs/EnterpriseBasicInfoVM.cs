using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using Safeway.ViewModel.CommonClass;
using Safeway.Model.System;
using Safeway.Model.SmallEntEvaluation;
namespace Safeway.ViewModel.EnterpriseBasicInfoVMs
{
    public class AdddressJsonObject
    {
        public string name { get; set; }
        public string id { get; set; }
        //public List<CityObject> CityObjects { get; set; }
    }
    public class ProvinceJsonObject
    {
        Dictionary<string, List<CityObject>> items { get; set; }
    }

    //public class commonObject 
    //{   
    //    public string key { get; set; }
    //    public List<CityObject> value { get; set; }
    //}
    public class CityObject
    {
        public string name { get; set; }
        public string id { get; set; }
        public string province { get; set; }
    }
    public class DistrictObject
    {
        public string name { get; set; }
        public string id { get; set; }
        public string city { get; set; }

    }
    public class AddressName
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public partial class EnterpriseBasicInfoVM : BaseCRUDVM<EnterpriseBasicInfo>
    {
        #region IncludingInfo

        public EnterpriseFinanceInfo  EnterpriseFinanceInfo{ get; set; }

        public EnterpriseBusinessinfo EnterpriseBusinessinfo { get; set; }

        public List<EnterpriseContact> EnterpriseContacts { get; set; }

        public List<EnterpriserYearYield> EnterpriserYearYields { get; set; }


        #endregion
        public string CityItemNames { get; set; }
        public List<string> ProvinceNames { get; set; }
        //public List<AddressName> CityNames { get; set; }
        public List<string> CityNmaes { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        public List<string> DistrictNames { get; set; }
        public List<AdddressJsonObject> ProvinceItems { get; set; }
        public List<AddressName> CityItems { get; set; }
        public EnterpriseBasicInfoVM()
        {
            // SetInclude(x => x.FinanceInfo, x => x.EnterpriseBusinessinfo, x => x.EnterpriseContacts, x => x.EnterpriserYearYields);
            //LoadProvince();
            //LoadEnterpriseInfo();
        }
        protected override void InitVM()
        {
            //LoadProvince();
            //LoadEnterpriseInfo();
        }

        public void LoadEnterpriseInfo() 
        {
            EnterpriseFinanceInfo = new EnterpriseFinanceInfo();
            EnterpriseBusinessinfo = new EnterpriseBusinessinfo();
            EnterpriseContacts = new List<EnterpriseContact>();
            EnterpriserYearYields = new List<EnterpriserYearYield>();
        }
        public void LoadListInfo(string id) 
        {
            EnterpriseContacts = DC.Set<EnterpriseContact>().Where(x => x.EnterpriseBasicInfoId== new Guid(id)).ToList();
            EnterpriserYearYields = DC.Set<EnterpriserYearYield>().Where(x => x.EnterpriseBasicInfoId == new Guid(id)).ToList();
        }
        public void LoadAdditionalInfo(string id) 
        {
            EnterpriseFinanceInfo = DC.Set<EnterpriseFinanceInfo>().Where(x => x.EnterpriseBasicId == new Guid(id)).FirstOrDefault();
            EnterpriseBusinessinfo = DC.Set<EnterpriseBusinessinfo>().Where(x => x.EnterpriseBasicInfoId == new Guid(id)).FirstOrDefault();
        }
        public void LoadAddressInfo(string id) 
        {
            var basic = DC.Set<EnterpriseBasicInfo>().Where(x => x.ID == new Guid(id)).FirstOrDefault();
            City = basic.City;
            District = basic.District;
        }
        public void LoadProvince()
        {
            //Load Province
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                                    "wwwroot", "custermisedui", "chinaregion", "province.json");
            using (StreamReader reader = new StreamReader(path))
            //using (JsonTextReader reader = new JsonTextReader(file))
            {
                string json = reader.ReadToEnd();
                ProvinceItems = JsonConvert.DeserializeObject<List<AdddressJsonObject>>(json);
            }
            var rv = ProvinceItems.Select(x => new { x.name }).ToList();
            ProvinceNames = new List<string>();
            foreach (var obj in rv)
            {
                ProvinceNames.Add(obj.name);
            }
            CityNmaes = new List<string>();
            DistrictNames = new List<string>();
        }
        public List<AddressName> GetCities(string keyword)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                                   "wwwroot", "custermisedui", "chinaregion", "city.json");
            var cityvalues = new Dictionary<string, List<CityObject>>();
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                cityvalues = JsonConvert.DeserializeObject<Dictionary<string, List<CityObject>>>(json);
            }

            var provinceid = ProvinceItems.Where(x => x.name == keyword).Select(x => x.id).FirstOrDefault();
            CityItems = cityvalues.Where(x => x.Key == provinceid).SelectMany(x => x.Value).Select(x => new AddressName { Text = x.name, Value = x.id }).ToList();
            CityItemNames = JsonConvert.SerializeObject(CityItems);
            var rv= cityvalues.Where(x => x.Key == provinceid).SelectMany(x => x.Value).Select(x => new  {  x.name }).ToList();
            List<AddressName> citynames = new List<AddressName>();
            foreach (var obj in rv) 
            {
                citynames.Add( new AddressName() { 
                     Text= obj.name,
                     Value = obj.name
                });
                CityNmaes.Add(obj.name);
            }
            
            return citynames;
        }
        public List<AddressName> GetDistricts(string keyword,string cityNames)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                           "wwwroot", "custermisedui", "chinaregion", "county.json");
            var districtvalues = new Dictionary<string, List<DistrictObject>>();
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                districtvalues = JsonConvert.DeserializeObject<Dictionary<string, List<DistrictObject>>>(json);
            }
            CityItems = JsonConvert.DeserializeObject<List<AddressName>>(cityNames);
            var cityId = CityItems.Where(x => x.Text == keyword).Select(x => x.Value).FirstOrDefault();
            List<DistrictObject> selectedDistricts = districtvalues[cityId];

            var districtNames = new List<AddressName >();
            foreach (var obj in selectedDistricts)
            {
                districtNames.Add(new AddressName() { 
                 Text = obj.name,
                 Value = obj.name
                });
                DistrictNames.Add(obj.name);
            }
          return districtNames;

        }

        public override void DoAdd()
        {           
            base.DoAdd();
            
        }
        public void DoAddFinanceInfo(EnterpriseFinanceInfo financeinfo)
        {
            DC.Set<EnterpriseFinanceInfo>().Add(financeinfo);
            DC.SaveChanges();
        }
        public void DoAddBusinnessInfo(EnterpriseBusinessinfo bussinessinfo)
        {
            DC.Set<EnterpriseBusinessinfo>().Add(bussinessinfo);
            DC.SaveChanges();
        }
        public void DoEditFinanceInfo(EnterpriseFinanceInfo financeinfo)
        {
            //check exist
            var data = DC.Set<EnterpriseFinanceInfo>().Where(x => x.EnterpriseBasicId == financeinfo.EnterpriseBasicId).FirstOrDefault();
            bool exist = data!= null ? true : false;
            if (exist)
            {
                DC.Set<EnterpriseFinanceInfo>().Remove(data);
            }

            DC.Set<EnterpriseFinanceInfo>().Add(financeinfo);
            DC.SaveChanges();
        }
        public void DoEditBusinnessInfo(EnterpriseBusinessinfo bussinessinfo)
        {
            var data = DC.Set<EnterpriseBusinessinfo>().Where(x => x.EnterpriseBasicInfoId == bussinessinfo.EnterpriseBasicInfoId).FirstOrDefault();
            bool exist = data != null ? true : false;
            if (exist)
            {
                DC.Set<EnterpriseBusinessinfo>().Remove(data);
            }

            DC.Set<EnterpriseBusinessinfo>().Add(bussinessinfo);
            DC.SaveChanges();


        }
        public void DoDeleteFinanceInfo(EnterpriseFinanceInfo financeinfo)
        {
            var data = DC.Set<EnterpriseFinanceInfo>().Where(x => x.EnterpriseBasicId == financeinfo.EnterpriseBasicId).FirstOrDefault();
            if (data != null)
            {
                DC.Set<EnterpriseFinanceInfo>().Remove(data);
                DC.SaveChanges();
            }
        }
        public void DoDeleteBusinnessInfo(EnterpriseBusinessinfo bussinessinfo)
        {
            var data = DC.Set<EnterpriseBusinessinfo>().Where(x => x.EnterpriseBasicInfoId == bussinessinfo.EnterpriseBasicInfoId).FirstOrDefault();
            if (data != null)
            {
                DC.Set<EnterpriseBusinessinfo>().Remove(data);
                DC.SaveChanges();
            }
        }
        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
        #region VuePage
        public List<AdddressJsonObject> GetProvinces() 
        {
            List<AdddressJsonObject> provinces = new List<AdddressJsonObject>();
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                                        "wwwroot", "custermisedui", "chinaregion", "province.json");
            using (StreamReader reader = new StreamReader(path))
            //using (JsonTextReader reader = new JsonTextReader(file))
            {
                string json = reader.ReadToEnd();
               provinces = JsonConvert.DeserializeObject<List<AdddressJsonObject>>(json);
            }
            return provinces;
        }

        public List<AdddressJsonObject> GetSelectedCities(string id)
        {
            List<AdddressJsonObject> cities = new List<AdddressJsonObject>();
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                                   "wwwroot", "custermisedui", "chinaregion", "city.json");
            var cityvalues = new Dictionary<string, List<CityObject>>();
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                cityvalues = JsonConvert.DeserializeObject<Dictionary<string, List<CityObject>>>(json);
            }
            cities = cityvalues.Where(x => x.Key == id).SelectMany(x => x.Value).Select(x => new AdddressJsonObject { name = x.name, id = x.id }).ToList();
            return cities;
        }
        public List<AdddressJsonObject> GetDistricts(string id) 
        {
            List<AdddressJsonObject> districts = new List<AdddressJsonObject>();
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                           "wwwroot", "custermisedui", "chinaregion", "county.json");
            var districtvalues = new Dictionary<string, List<DistrictObject>>();
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                districtvalues = JsonConvert.DeserializeObject<Dictionary<string, List<DistrictObject>>>(json);
            }
            districts = districtvalues.Where(x => x.Key == id).SelectMany(x => x.Value).Select(x => new AdddressJsonObject { name = x.name, id = x.id }).ToList();
            return districts;
        }
        public string AddNewEnterpriseInfo(params string[] parameters) {

            var basicInfo = new EnterpriseBasicInfo();
            var businessInfoList = new List<EnterpriseBusinessinfo>();
            var contactList = new List<EnterpriseContact>();
            var yearYieldList = new List<EnterpriserYearYield>();
            var financeInfo = new EnterpriseFinanceInfo();

            if (parameters[0] != null && parameters[0].Length >2 && !string.IsNullOrEmpty(parameters[0])) 
            {
                basicInfo = JsonConvert.DeserializeObject<EnterpriseBasicInfo>(parameters[0]);
                DC.Set<EnterpriseBasicInfo>().Add(basicInfo);
            }
            if (parameters[1] != null && parameters[1].Length > 2 &&  !string.IsNullOrEmpty(parameters[1])) 
            {           
                businessInfoList = JsonConvert.DeserializeObject<List<EnterpriseBusinessinfo>>(parameters[1]);
                DC.Set<EnterpriseBusinessinfo>().AddRange(businessInfoList);              
            }
            if (parameters[2] != null && parameters[2].Length > 2 && !string.IsNullOrEmpty(parameters[2]))
            {
                financeInfo = JsonConvert.DeserializeObject<EnterpriseFinanceInfo>(parameters[2]);
                DC.Set<EnterpriseFinanceInfo>().Add(financeInfo);
            }
            if (parameters[3] != null && parameters[3].Length > 2 && !string.IsNullOrEmpty(parameters[3]))
            {
                contactList = JsonConvert.DeserializeObject<List<EnterpriseContact>>(parameters[3]);
                DC.Set<EnterpriseContact>().AddRange(contactList);
            }
            if (parameters[4] != null && parameters[4].Length > 2 && !string.IsNullOrEmpty(parameters[4]))
            {
                yearYieldList = JsonConvert.DeserializeObject<List<EnterpriserYearYield>>(parameters[4]);
                DC.Set<EnterpriserYearYield>().AddRange(yearYieldList);
            }
             DC.SaveChanges();
            return DC.SaveChanges().ToString();
        }
        public string EditNewEnterpriseInfo(params string[] parameters)
        {

            var basicInfo = new EnterpriseBasicInfo();
            var businessInfoList = new List<EnterpriseBusinessinfo>();
            var contactList = new List<EnterpriseContact>();
            var yearYieldList = new List<EnterpriserYearYield>();
            var financeInfo = new EnterpriseFinanceInfo();

            if (parameters[0] != null && parameters[0].Length > 2 && !string.IsNullOrEmpty(parameters[0]))
            {
                basicInfo = JsonConvert.DeserializeObject<EnterpriseBasicInfo>(parameters[0]);
                DC.Set<EnterpriseBasicInfo>().Update(basicInfo);
            }
            if (parameters[1] != null && parameters[1].Length >2 && !string.IsNullOrEmpty(parameters[1]))
            {
                businessInfoList = JsonConvert.DeserializeObject<List<EnterpriseBusinessinfo>>(parameters[1]);
                DC.Set<EnterpriseBusinessinfo>().UpdateRange(businessInfoList);
            }
            if (parameters[2] != null && parameters[2].Length > 2 && !string.IsNullOrEmpty(parameters[2]))
            {
                financeInfo = JsonConvert.DeserializeObject<EnterpriseFinanceInfo>(parameters[2]);
                DC.Set<EnterpriseFinanceInfo>().Update(financeInfo);
            }
            if (parameters[3] != null && parameters[3].Length > 2 && !string.IsNullOrEmpty(parameters[3]))
            {
                contactList = JsonConvert.DeserializeObject<List<EnterpriseContact>>(parameters[3]);
                DC.Set<EnterpriseContact>().UpdateRange(contactList);
            }
            if (parameters[4] != null && parameters[4].Length >2 && !string.IsNullOrEmpty(parameters[4]))
            {
                yearYieldList = JsonConvert.DeserializeObject<List<EnterpriserYearYield>>(parameters[4]);
                DC.Set<EnterpriserYearYield>().UpdateRange(yearYieldList);
            }
            DC.SaveChanges();
            return DC.SaveChanges().ToString();
        }
            //Delete Enterprise Info
            public string DeleteEnterpriseInfo(string id)
            {
                Guid enterpriseId = new Guid(id);
                var businessData = DC.Set<EnterpriseBusinessinfo>().Where(x => x.EnterpriseBasicInfoId == enterpriseId).ToList();
                var financeData = DC.Set<EnterpriseFinanceInfo>().Where(x => x.EnterpriseBasicId == enterpriseId).FirstOrDefault();
                var contactData = DC.Set<EnterpriseContact>().Where(x => x.EnterpriseBasicInfoId == enterpriseId).ToList();
                var yearYieldData = DC.Set<EnterpriserYearYield>().Where(x => x.EnterpriseBasicInfoId == enterpriseId).ToList();
                base.DoDelete();
                if (businessData.Count>0) 
                {
                    DC.Set<EnterpriseBusinessinfo>().RemoveRange(businessData);                  
                }
                if (financeData != null) 
                {
                    DC.Set<EnterpriseFinanceInfo>().Remove(financeData);
                }
                if (contactData.Count > 0)
                {
                    DC.Set<EnterpriseContact>().RemoveRange(contactData);
                }

                if (yearYieldData.Count > 0)
                {
                    DC.Set<EnterpriserYearYield>().RemoveRange(yearYieldData);
                }

                DC.SaveChanges();
                return DC.SaveChanges().ToString();
            }
            public List<string> GetEnterpriseInfo(string basicid) 
            {
            List<string> result = new List<string>();
            var data = DC.Set<EnterpriseBasicInfo>().Where(x => x.ID == new Guid(basicid)).FirstOrDefault();
            if (data != null) 
            {
               var tempresult = JsonConvert.SerializeObject(data);
                result.Add(tempresult);
            }
            var businessdata = DC.Set<EnterpriseBusinessinfo>().Where(x => x.EnterpriseBasicInfoId == new Guid(basicid)).ToList();
            if (businessdata != null)
            {
               var tempresult = JsonConvert.SerializeObject(businessdata);
               result.Add(tempresult);
            }
            var financedata = DC.Set<EnterpriseFinanceInfo>().Where(x => x.EnterpriseBasicId == new Guid(basicid)).FirstOrDefault();
            if (financedata != null)
            {
                var tempresult = JsonConvert.SerializeObject(financedata);
                result.Add(tempresult);
            }

            var contactlist = DC.Set<EnterpriseContact>().Where(x => x.EnterpriseBasicInfoId == new Guid(basicid)).ToList();
            if (contactlist != null)
            {
                var tempresult = JsonConvert.SerializeObject(contactlist);
                result.Add(tempresult);
            }

            var yearYieldList = DC.Set<EnterpriserYearYield>().Where(x => x.EnterpriseBasicInfoId == new Guid(basicid)).ToList();
            if (yearYieldList != null)
            {
                var tempresult = JsonConvert.SerializeObject(yearYieldList);
                result.Add(tempresult);
            }
            return result;
        }


        public List<DictionaryItem> GetDictionaryData(string dictionaryCode)
        {
            List<DictionaryItem> result = new List<DictionaryItem>();
            var alldata = DC.Set<SysDictionaryItem>().ToList();
            var childrenCodes = DC.Set<SysDictionaryType>().Where(x => x.ParentCode == dictionaryCode && x.IsValid == true).Select(x => new DictionaryItem() { 
              label =x.Name,
              value =x.Code          
            }).ToList();

            result = alldata.Where(x => x.Code == dictionaryCode).OrderBy(x => x.Sort).Select(x => new DictionaryItem()
            {
                label = x.Value,
                value = x.Value
            }).ToList();

            for (int i = 0; i < result.Count; i++) 
            {
                for (int j = 0; j < childrenCodes.Count; j++) 
                {
                    if (result[i].label == childrenCodes[j].label) 
                    {
                        result[i].children = alldata.Where(x => x.Code ==childrenCodes[j].value).OrderBy(x => x.Sort).Select(x => new DictionaryItem()
                        {
                            label = x.Value,
                            value = x.Value
                        }).ToList();
                    }
                
                }            
            }

            return result;
        }
        public string GetEnterprisebyEvaluationId(string id) 
        {
            string enterpriseid = "";
            var evaluationData = DC.Set<SmallEntEvaluationBase>().Where(x => x.ID == new Guid(id)).FirstOrDefault();
            if (evaluationData != null) 
            {
                enterpriseid = evaluationData.EnterpriseId;
            }
            return enterpriseid;
        }

        public List<string> GetLimitedEnterpriseInfo(string basicId) 
        {
            List<string> result = new List<string>();
            var data = DC.Set<EnterpriseBasicInfo>().Where(x => x.ID == new Guid(basicId)).FirstOrDefault();
            if (data != null)
            {
                var tempresult = JsonConvert.SerializeObject(data);
                result.Add(tempresult);
            }
            var contactlist = DC.Set<EnterpriseContact>().Where(x => x.EnterpriseBasicInfoId == new Guid(basicId)).ToList();
            if (contactlist != null)
            {
                var tempresult = JsonConvert.SerializeObject(contactlist);
                result.Add(tempresult);
            }
            return result;
        }
        public string EditLimitedEnterpriseInfo(params string[] parameters)
        {
            var basicInfo = new EnterpriseBasicInfo();
            var contactList = new List<EnterpriseContact>();
            if (parameters[0] != null && parameters[0].Length > 2 && !string.IsNullOrEmpty(parameters[0]))
            {
                basicInfo = JsonConvert.DeserializeObject<EnterpriseBasicInfo>(parameters[0]);
                DC.Set<EnterpriseBasicInfo>().Update(basicInfo);
            }
            if (parameters[1] != null && parameters[1].Length > 2 && !string.IsNullOrEmpty(parameters[1]))
            {
                contactList = JsonConvert.DeserializeObject<List<EnterpriseContact>>(parameters[1]);
                DC.Set<EnterpriseContact>().UpdateRange(contactList);
            }
            DC.SaveChanges();
            return DC.SaveChanges().ToString();
        }
        #endregion
    }
}

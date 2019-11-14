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
            LoadProvince();
            LoadEnterpriseInfo();
        }
        protected override void InitVM()
        {
            LoadProvince();
            LoadEnterpriseInfo();
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
    }
}

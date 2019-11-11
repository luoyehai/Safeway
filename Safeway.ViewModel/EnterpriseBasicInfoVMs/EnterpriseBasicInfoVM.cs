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
        //public List<ComboSelectListItem> AllBasicInfos { get; set; }
        //[JsonIgnore]
        //public List<ComboSelectListItem> AllContacts { get; set; }
        //[Display(Name = "联系人")]
        //public List<Guid> SelectedContactsIDs { get; set; }

        //[JsonIgnore]
        //public List<ComboSelectListItem> AllYearlyYields { get; set; }
        //[Display(Name = "年收益")]
        //public List<Guid> SelectedYieldsIDs { get; set; }

        #endregion
        public string CityItemNames { get; set; }
        public List<string> ProvinceNames { get; set; }
        //public List<AddressName> CityNames { get; set; }
        public List<AdddressJsonObject> ProvinceItems { get; set; }
        public List<AddressName> CityItems { get; set; }
        public EnterpriseBasicInfoVM()
        {
            SetInclude(x => x.FinanceInfo, x => x.EnterpriseBusinessinfo, x => x.EnterpriseContacts, x => x.EnterpriserYearYields);
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
            //AllBasicInfos = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
            //SelectedContactsIDs = Entity.EnterpriseContacts.Select(x => x.EnterpriseBasicInfoId).ToList();
            //AllContacts = DC.Set<EnterpriseContact>().GetSelectListItems(LoginUserInfo.DataPrivileges, null, y => y.EnterpriseBasicInfoId.ToString());
            //SelectedYieldsIDs = Entity.EnterpriserYearYields.Select(x => x.EnterpriseBasicInfoId).ToList();
            //AllYearlyYields = DC.Set<EnterpriserYearYield>().GetSelectListItems(LoginUserInfo.DataPrivileges, null, y => y.EnterpriseBasicInfoId.ToString());

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
            //Session = "t";
            // HttpContext.Session.SetString("code", "123456");
            CityItemNames = JsonConvert.SerializeObject(CityItems);
            var rv= cityvalues.Where(x => x.Key == provinceid).SelectMany(x => x.Value).Select(x => new AddressName { Text = x.name, Value = x.name }).ToList();
            return rv;
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
            // var provinceid = ProvinceItems.Where(x => x.name == keyword).Select(x => x.id).FirstOrDefault();
            // (cityObj as IEnumerable)

            // var rv = districtvalues.Where(x => x.Key == provinceid).SelectMany(x => x.Value).Select(x => new AddressName { Text = x.name, Value = x.id }).ToList();
            CityItems = JsonConvert.DeserializeObject<List<AddressName>>(cityNames);
            var cityId = CityItems.Where(x => x.Text == keyword).Select(x => x.Value).FirstOrDefault();
            List<DistrictObject> selectedDistricts = districtvalues[cityId];

            var DistrictNames = new List<AddressName>();
            foreach (var obj in selectedDistricts)
            {
                DistrictNames.Add(new AddressName()
                {
                    Text = obj.name,
                    Value = obj.name
                });
            }
            return DistrictNames;

        }
        //public string GetCityIdbyName(string name) 
        //{ 
        
        
        //}
        //protected override void InitVM()
        //{
        //}

        public override void DoAdd()
        {           
            base.DoAdd();
            
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

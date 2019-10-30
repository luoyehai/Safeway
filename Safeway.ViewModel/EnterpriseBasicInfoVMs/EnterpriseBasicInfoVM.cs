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
    public class AddressName
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public partial class EnterpriseBasicInfoVM : BaseCRUDVM<EnterpriseBasicInfo>
    {      
        public List<string> ProvinceNames { get; set; }
        public List<AddressName> CityNames { get; set; }
        public List<AdddressJsonObject> ProvinceItems { get; set; }
        public ProvinceJsonObject CityItems { get; set; }
        public List<AdddressJsonObject> DistrictItems { get; set; }
        public EnterpriseBasicInfoVM()
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
            var rv = ProvinceItems.Select(x => new {x.name}).ToList();
            ProvinceNames = new List<string>();
            foreach (var obj in rv) {
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
            // (cityObj as IEnumerable)
            List<CityObject> particularcities = cityvalues[provinceid];

            CityNames = new List<AddressName>();
            foreach (var obj in particularcities)
            {
                CityNames.Add(new AddressName() { 
                    Text = obj.name,
                    Value = obj.id
                });
            }
            return CityNames;
        }
            

        protected override void InitVM()
        {
        }

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

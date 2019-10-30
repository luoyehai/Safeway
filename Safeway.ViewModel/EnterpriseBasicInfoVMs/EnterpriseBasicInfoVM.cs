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

namespace Safeway.ViewModel.EnterpriseBasicInfoVMs
{
    public class AdddressJsonObject
    {
        public string name { get; set; }
        public string id { get; set; }
    }
    public class AdddressName
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public partial class EnterpriseBasicInfoVM : BaseCRUDVM<EnterpriseBasicInfo>
    {      
        public List<string> ProvinceNames { get; set; }
        public List<AdddressJsonObject> ProvinceItems { get; set; }
        public List<AdddressJsonObject> CityItems { get; set; }
        public List<AdddressJsonObject> DistrictItems { get; set; }
        public EnterpriseBasicInfoVM()
        {
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

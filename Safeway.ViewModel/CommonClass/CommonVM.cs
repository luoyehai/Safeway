using Safeway.Model.Project;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Enterprise;
using Safeway.Model.System;

namespace Safeway.ViewModel.CommonClass
{
    public class CommonVM : BaseVM
    {
        public List<ComboSelectListItem> GetProjects()
        {
            return DC.Set<ProjectBasicInfo>().Where(x => x.IsValid.Equals(true)).OrderByDescending(x => x.CreateTime).Select(x =>
            new ComboSelectListItem()
            {
                Text = x.ProjectName,
                Value = x.ID.ToString()
            }).ToList();
        }

        public List<ComboSelectListItem> GetEnterprises()
        {
            return DC.Set<EnterpriseBasicInfo>().OrderByDescending(x => x.ComapanyName).Select(x =>
            new ComboSelectListItem()
            {
                Text = x.ComapanyName,
                Value = x.ID.ToString()
            }).ToList();
        }

        public List<ComboSelectListItem> GetDictionaryItems(string code)
        {
            return DC.Set<SysDictionaryItem>().Where(x => x.Code.Equals(code)).OrderBy(x => x.Name).Select(x =>
            new ComboSelectListItem()
            {
                Text = x.Name,
                Value = x.Value
            }).ToList();
        }
    }
}

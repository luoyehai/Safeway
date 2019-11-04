﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.NormalEntEvaluationTemplateVMs
{
    public partial class NormalEntEvaluationTemplateVM : BaseCRUDVM<NormalEntEvaluationTemplate>
    {
        public List<ComboSelectListItem> AllEnterpriseBasicInfos { get; set; }

        public NormalEntEvaluationTemplateVM()
        {
            SetInclude(x => x.EnterpriseBasicInfo);
        }

        protected override void InitVM()
        {
            AllEnterpriseBasicInfos = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.NormalEntEvaluationTemplateVMs
{
    public partial class NormalEntEvaluationTemplateTemplateVM : BaseTemplateVM
    {
        [Display(Name = "评审单位")]
        public ExcelPropety EvluationEnt_Excel = ExcelPropety.CreateProperty<NormalEntEvaluationTemplate>(x => x.EvluationEnt);
        [Display(Name = "评审开始时间")]
        public ExcelPropety EvaluationStartDate_Excel = ExcelPropety.CreateProperty<NormalEntEvaluationTemplate>(x => x.EvaluationStartDate);
        [Display(Name = "评审结束时间")]
        public ExcelPropety EvaluationEndDate_Excel = ExcelPropety.CreateProperty<NormalEntEvaluationTemplate>(x => x.EvaluationEndDate);
        [Display(Name = "评审组组长")]
        public ExcelPropety EvaluationLeader_Excel = ExcelPropety.CreateProperty<NormalEntEvaluationTemplate>(x => x.EvaluationLeader);
        [Display(Name = "评审组成员")]
        public ExcelPropety EvaluationTeamMember_Excel = ExcelPropety.CreateProperty<NormalEntEvaluationTemplate>(x => x.EvaluationTeamMember);
        [Display(Name = "模块一")]
        public ExcelPropety ModuleOne_Excel = ExcelPropety.CreateProperty<NormalEntEvaluationTemplate>(x => x.ModuleOne);
        [Display(Name = "模块二")]
        public ExcelPropety ModuleTwo_Excel = ExcelPropety.CreateProperty<NormalEntEvaluationTemplate>(x => x.ModuleTwo);
        [Display(Name = "模块三")]
        public ExcelPropety ModuleThree_Excel = ExcelPropety.CreateProperty<NormalEntEvaluationTemplate>(x => x.ModuleThree);
        public ExcelPropety EnterpriseBasicInfo_Excel = ExcelPropety.CreateProperty<NormalEntEvaluationTemplate>(x => x.EnterpriseId);

	    protected override void InitVM()
        {
            EnterpriseBasicInfo_Excel.DataType = ColumnDataType.ComboBox;
            EnterpriseBasicInfo_Excel.ListItems = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
        }

    }

    public class NormalEntEvaluationTemplateImportVM : BaseImportVM<NormalEntEvaluationTemplateTemplateVM, NormalEntEvaluationTemplate>
    {

    }

}

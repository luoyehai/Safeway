using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;
using Safeway.Model.Common;


namespace Safeway.ViewModel.DetailNotmalEntEvaluationVMs
{
    public partial class DetailNotmalEntEvaluationTemplateVM : BaseTemplateVM
    {
        [Display(Name = "文件/现场")]
        public ExcelPropety EvaluateType_Excel = ExcelPropety.CreateProperty<DetailNotmalEntEvaluation>(x => x.EvaluateType);
        [Display(Name = "选择")]
        public ExcelPropety EvaluationSelection_Excel = ExcelPropety.CreateProperty<DetailNotmalEntEvaluation>(x => x.EvaluationSelection);
        [Display(Name = "扣分参考")]
        public ExcelPropety DeductionReference_Excel = ExcelPropety.CreateProperty<DetailNotmalEntEvaluation>(x => x.DeductionReference);
        [Display(Name = "扣分")]
        public ExcelPropety Deduction_Excel = ExcelPropety.CreateProperty<DetailNotmalEntEvaluation>(x => x.Deduction);
        [Display(Name = "扣分描述参考")]
        public ExcelPropety DeductionDescription_Excel = ExcelPropety.CreateProperty<DetailNotmalEntEvaluation>(x => x.DeductionDescription);
        public ExcelPropety NormalEntEvaluation_Excel = ExcelPropety.CreateProperty<DetailNotmalEntEvaluation>(x => x.NormalEntEvaluationId);

	    protected override void InitVM()
        {
            NormalEntEvaluation_Excel.DataType = ColumnDataType.ComboBox;
            NormalEntEvaluation_Excel.ListItems = DC.Set<NormalEntEvaluation>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComplianceStandard);
        }

    }

    public class DetailNotmalEntEvaluationImportVM : BaseImportVM<DetailNotmalEntEvaluationTemplateVM, DetailNotmalEntEvaluation>
    {

    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;


namespace Safeway.ViewModel.NormalEntEvaluationTemplateVMs
{
    public partial class NormalEntEvaluationTemplateBatchVM : BaseBatchVM<NormalEntEvaluationTemplate, NormalEntEvaluationTemplate_BatchEdit>
    {
        public NormalEntEvaluationTemplateBatchVM()
        {
            ListVM = new NormalEntEvaluationTemplateListVM();
            LinkedVM = new NormalEntEvaluationTemplate_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class NormalEntEvaluationTemplate_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}

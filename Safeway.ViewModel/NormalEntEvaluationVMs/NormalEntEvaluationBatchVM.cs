using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;


namespace Safeway.ViewModel.NormalEntEvaluationVMs
{
    public partial class NormalEntEvaluationBatchVM : BaseBatchVM<NormalEntEvaluation, NormalEntEvaluation_BatchEdit>
    {
        public NormalEntEvaluationBatchVM()
        {
            ListVM = new NormalEntEvaluationListVM();
            LinkedVM = new NormalEntEvaluation_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class NormalEntEvaluation_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}

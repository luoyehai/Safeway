using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;


namespace Safeway.ViewModel.DetailNotmalEntEvaluationVMs
{
    public partial class DetailNotmalEntEvaluationBatchVM : BaseBatchVM<DetailNotmalEntEvaluation, DetailNotmalEntEvaluation_BatchEdit>
    {
        public DetailNotmalEntEvaluationBatchVM()
        {
            ListVM = new DetailNotmalEntEvaluationListVM();
            LinkedVM = new DetailNotmalEntEvaluation_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class DetailNotmalEntEvaluation_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.SmallEntEvaluation;


namespace Safeway.ViewModel.SmallEntEvaluationBaseVMs
{
    public partial class SmallEntEvaluationBaseBatchVM : BaseBatchVM<SmallEntEvaluationBase, SmallEntEvaluationBase_BatchEdit>
    {
        public SmallEntEvaluationBaseBatchVM()
        {
            ListVM = new SmallEntEvaluationBaseListVM();
            LinkedVM = new SmallEntEvaluationBase_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class SmallEntEvaluationBase_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}

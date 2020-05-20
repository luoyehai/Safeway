using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.BasicEntEvaluation;


namespace Safeway.ViewModel.BasicEntEvaluationBaseVMs
{
    public partial class BasicEntEvaluationBaseBatchVM : BaseBatchVM<BasicEntEvaluationBase, BasicEntEvaluationBase_BatchEdit>
    {
        public BasicEntEvaluationBaseBatchVM()
        {
            ListVM = new BasicEntEvaluationBaseListVM();
            LinkedVM = new BasicEntEvaluationBase_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class BasicEntEvaluationBase_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}

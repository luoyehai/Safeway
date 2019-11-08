using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.NormalEntEvaluation;


namespace Safeway.ViewModel.NormalEntEvaluationBaseVMs
{
    public partial class NormalEntEvaluationBaseBatchVM : BaseBatchVM<NormalEntEvaluationBase, NormalEntEvaluationBase_BatchEdit>
    {
        public NormalEntEvaluationBaseBatchVM()
        {
            ListVM = new NormalEntEvaluationBaseListVM();
            LinkedVM = new NormalEntEvaluationBase_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class NormalEntEvaluationBase_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}

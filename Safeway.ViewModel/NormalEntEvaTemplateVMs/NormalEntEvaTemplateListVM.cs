using System;
using System.Collections.Generic;
using System.Text;
using Safeway.Model.Evaluation;
using Safeway.DataAccess;
using WalkingTec.Mvvm.Core;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Enterprise;

namespace Safeway.ViewModel.NormalEntEvaTemplateListVMs
{
    public class NormalEntEvaTemplateListVM: BaseVM
    {

        public IEnumerator<NormalEntEvaTemplate_View> Index() {


            var query = DC.Set<NormalEntEvaTemplate_View>().OrderBy(x => x.ID).GetEnumerator();
            return query;
        }
        public class NormalEntEvaTemplate_View : NormalEntEvaluationTemplate
        {
            [Display(Name = "公司名称")]
            public String ComapanyName_view { get; set; }

        }
    }
}

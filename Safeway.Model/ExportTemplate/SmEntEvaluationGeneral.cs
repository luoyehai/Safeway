using System;
using System.Collections.Generic;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Safeway.Model.ExportTemplate
{
    public class SmEntEvaluationGeneral
    {
        [Key]
        public Guid EnterpriseID { get; set; }
        public string ComapanyName { get; set; }
        public string Industry { get; set; }
        public DateTime EvaluationStartDate { get; set; }
        public string LegalRepresentative { get; set; }
        public string LegalRepTel { get; set; }
        public string LegalRepMobile { get; set; }
        public string ContactName { get; set; }
        public string ContactTel { get; set; }
        public string ContactFax { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public string EvaluationLeader { get; set; }
        public string EvaluationTeamMember { get; set; }
        public DateTime EvaluationEndDate { get; set; }

    }
}

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
    public class SmEntEvaluationTemplate 
    {
        [Key]
        public Guid ID { get; set; }
        public Guid LevelFourID { get; set; }
        public string LevelOneElement { get; set; }
        public string LevelTwoElement { get; set; }
        public string ComplianceStandard { get; set; }
        public decimal ActualScore { get; set; }
        public string ScoringMethod { get; set; }
        public decimal Deduction { get; set; }
        public string UnMatchedItemDescription { get; set; }
        public bool UnInvolved { get; set; }
        public decimal StandardScore { get; set; }
    }
}

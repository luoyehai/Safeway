using System;
using System.Collections.Generic;
using System.Text;

namespace Safeway.Model.ExportTemplate
{
    public class SmEntEvaluationTemplate
    {
        public Guid LevelFourID { get; set; }
        public string ComplianceStandard { get; set; }
        public decimal ActualScore { get; set; }
        public string ScoringMethod { get; set; }
        public decimal Deduction { get; set; }
        public string UnMatchedItemDescription { get; set; }
    }
}

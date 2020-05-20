using System;
using System.Collections.Generic;
using System.Text;

namespace Safeway.Model.BasicEntEvaluation
{
    public class BasicEntEvaluationItemStateTrack
    {
        public Guid ID { get; set; }

        public Guid BasicEntEvaluationItemID { get; set; }

        public string State { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}

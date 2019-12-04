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
    public class EvaluationTeamInfo
    {
        [Key]
        public Guid ID { get; set; }
        public string ProjectID { get; set; }
        public string SmallEntEvaBaseID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}

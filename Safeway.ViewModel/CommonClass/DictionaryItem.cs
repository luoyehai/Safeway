using System;
using System.Collections.Generic;
using System.Text;

namespace Safeway.ViewModel.CommonClass
{
    public class DictionaryItem
    {
       public string label { get; set; }
       public string value { get; set; }
       public List<DictionaryItem> children { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS.Model
{
    public class MemberControl
    {
        public string MemberControlType { get; set; }
        public List<MemberControlItem> _ItmeItems { get; set; }
    }
}

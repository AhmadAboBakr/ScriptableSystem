using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableSystem
{
    public class ScriptableInt : ScriptableVariable<int>
    {
        public override void Parse(string value)
        {
            this.value = int.Parse(value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMapper
{
    /// <summary>
    /// Equivelent to Auto Increment in EF
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class AutoCalculate:Attribute
    {
        
    }
}

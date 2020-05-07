using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMapper.Attributes
{
    /// <summary>
    /// Equivelent to Key attribute in EF
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EntityKey:Attribute
    {
    }
}

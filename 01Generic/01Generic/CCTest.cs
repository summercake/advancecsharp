using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Generic
{
    /// <summary>
    /// out ---- covariant 协变 修饰返回值 child to parent
    /// in ----- contravariant 逆变 修饰传入的参数 parent to child
    /// </summary>
    public class CCTest
    {
        // List<Parent> is not base class of List<Child>
        // They are two independent type
        // List<Parent> pList = new List<Child>();

        // 1. use linq to change type of child
        List<Parent> list = new List<Child>().Select(c => (Parent)c).ToList();
        // 2. use covariant
        IEnumerable<Parent> pList = new List<Child>();
    }
}

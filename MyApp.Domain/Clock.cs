using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public class Clock
    {
        public static Func<DateTime> Now = () => DateTime.UtcNow;

        public static void Reset()
        {
            Now = () => DateTime.UtcNow;
        }
    }
}

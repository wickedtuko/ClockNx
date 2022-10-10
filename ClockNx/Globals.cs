using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if WINDOWS
using Windows.Graphics;
#endif

namespace ClockNx
{
    public class Globals
    {
        private static readonly Globals instance = new Globals();
        public static Globals GetGlobals()
        {
            return instance;
        }

#if WINDOWS
        public SizeInt32 ActualClientSize { get; set; }
#endif

    }
}

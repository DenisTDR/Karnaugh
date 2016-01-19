using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karnaugh
{
    public static class Extensions
    {
        public static ThingState GetNext(this ThingState state)
        {
            switch (state)
            {
                case ThingState.False:
                    return ThingState.True;
                case ThingState.True:
                    return ThingState.DontCare;
                case ThingState.DontCare:
                    return ThingState.False;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        public static char GetLogicValue(this ThingState state)
        {
            switch (state)
            {
                case ThingState.False:
                    return '0';
                case ThingState.True:
                    return '1';
                case ThingState.DontCare:
                    return '-';
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
        public static int GetIntValue(this ThingState state)
        {
            switch (state)
            {
                case ThingState.False:
                    return 0;
                case ThingState.True:
                    return 1;
                case ThingState.DontCare:
                    return 2;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}

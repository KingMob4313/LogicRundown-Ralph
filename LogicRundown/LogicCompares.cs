using System;

namespace LogicRundown
{
    static class LogicCompares
    {
        public static bool CompareLessThan(int AlphaValue, int BetaValue, bool Inverter)
        {
            return (InvertBoolValue((Inverter), (AlphaValue < BetaValue)));
        }

        public static bool CompareDividedBy(int AlphaValue, int BetaValue, bool Inverter)
        {
            return (InvertBoolValue((Inverter), (BetaValue % AlphaValue == 0)));
        }

        private static bool InvertBoolValue(bool shouldInvert, bool assessment)
        {
            return (shouldInvert ? !assessment : assessment);
        }
    }
}

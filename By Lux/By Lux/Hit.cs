using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;

namespace By_Lux
{
    internal class Hit
    {
            public static HitChance HitQ()
        {
            switch (Menux.LuxMenu["HitQ"].Cast<ComboBox>().CurrentValue)
            {
                case 0:
                    return HitChance.Low;
                case 1:
                    return HitChance.Medium;
                case 2:
                    return HitChance.High;
                default:
                    return HitChance.Unknown;
            }
        }
        public static HitChance HitE()
        {
            switch (Menux.LuxMenu["HitE"].Cast<ComboBox>().CurrentValue)
            {
                case 0:
                    return HitChance.Low;
                case 1:
                    return HitChance.Medium;
                case 2:
                    return HitChance.High;
                default:
                    return HitChance.Unknown;
            }
        }
        public static HitChance HitR()
        {
            switch (Menux.LuxMenu["HitR"].Cast<ComboBox>().CurrentValue)
            {
                case 0:
                    return HitChance.Low;
                case 1:
                    return HitChance.Medium;
                case 2:
                    return HitChance.High;
                default:
                    return HitChance.Unknown;
            }
        }
    }
}
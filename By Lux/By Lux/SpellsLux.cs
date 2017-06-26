using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace By_Lux
{
    internal class SpellsLux
    {
        private static AIHeroClient myHero
        {
            get { return Player.Instance; }
        }

        public static Spell.Skillshot Q;
        public static Spell.Skillshot W;
        public static Spell.Skillshot E;
        public static Spell.Skillshot R;

        public SpellsLux()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 1175, SkillShotType.Linear, 250, 1200, 70)
             {
                 AllowedCollisionCount = 1
             };

            W = new Spell.Skillshot(SpellSlot.W, 1075, SkillShotType.Linear);

            E = new Spell.Skillshot(SpellSlot.E, 1100, SkillShotType.Circular, 250, 1400, 335)
            {
                AllowedCollisionCount = int.MaxValue
            };

            R = new Spell.Skillshot(SpellSlot.R, 3340, SkillShotType.Circular, 1000, int.MaxValue, 110)
            {
                AllowedCollisionCount = int.MaxValue
            };

        }

    }
}

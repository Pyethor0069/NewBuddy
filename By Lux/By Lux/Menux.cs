using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace By_Lux
{
    internal class Menux
    {
        public static Menu LuxMenu;

        public Menux()
        {
            LuxMenu = MainMenu.AddMenu("Lux", "Lux");
            LuxMenu.AddLabel("Controls");
            LuxMenu.Add("Co", new CheckBox("Active Combo"));
            LuxMenu.Add("Int", new CheckBox("Active interrupt"));
            LuxMenu.Add("Ha", new CheckBox("Active Harass"));
            LuxMenu.Add("Le", new CheckBox("Active LaneClear"));
            LuxMenu.Add("Ju", new CheckBox("Active JungleClear"));
            LuxMenu.AddLabel("Controls HitChance");
            LuxMenu.Add("HitQ", new ComboBox("HitChance [Q]", 1, "Low", "Medium", "High"));
            LuxMenu.Add("HitE", new ComboBox("HitChance [E]", 2, "Low", "Medium", "High"));
            LuxMenu.Add("HitR", new ComboBox("HitChance [R]", 1, "Low", "Medium", "High"));
            LuxMenu.AddLabel("Controls Spell [R]");
            LuxMenu.Add("MinR", new Slider("Minimum of Enemies", 2, 1, 5));
            LuxMenu.Add("KilR", new CheckBox("Use [R] KillSteal"));
            LuxMenu.AddLabel("Controls [KillSteal]");
            LuxMenu.Add("KilQ", new CheckBox("Use [Q] KillSteal"));
            LuxMenu.Add("KilE", new CheckBox("Use [E] KillSteal"));
            LuxMenu.AddLabel("Controls Spell [W]");
            LuxMenu.Add("UseW", new CheckBox("Use [W]"));
            LuxMenu.Add("USeHet", new Slider("Mini Life", 50, 1, 100));
            LuxMenu.AddLabel("Controls Lane and Jungle");
            LuxMenu.Add("LaneQ", new CheckBox("Use Q LaneClear", false));
            LuxMenu.Add("LaneE", new CheckBox("Use E LaneCLaer"));
            LuxMenu.Add("MinionE", new Slider("Minions [Max]", 3, 1, 5));
            LuxMenu.Add("ManaLane", new Slider("Mana [LaneClear]", 50, 1, 100));
            LuxMenu.AddLabel("JungleClear");
            LuxMenu.Add("JungleQ", new CheckBox("Use Q JungleClear", false));
            LuxMenu.Add("JungleE", new CheckBox("Use E JungleCLaer"));
            LuxMenu.Add("ManaJungle", new Slider("Mana [JungleClear]", 50, 1, 100));
            LuxMenu.AddLabel("Drawing");
            LuxMenu.Add("QD", new CheckBox("[Q] Draw"));
            LuxMenu.Add("WD", new CheckBox("[W] Draw"));
            LuxMenu.Add("ED", new CheckBox("[E] Draw"));
            LuxMenu.Add("RD", new CheckBox("[R] Draw"));


        }
    }
}
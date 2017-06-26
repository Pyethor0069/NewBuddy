using EloBuddy;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using static By_Lux.SpellsLux;
using System;

namespace By_Lux
{
    internal class Drawings
    {
        public Drawings()
        {
            //New
        }

        internal static void OnDraw(EventArgs args)
        {
            if (Menux.LuxMenu["QD"].Cast<CheckBox>().CurrentValue)
            {
                new Circle { Color = System.Drawing.Color.LightCyan, Radius = Q.Range, BorderWidth = 2f }.Draw
                    (Player.Instance.Position);
            }
            if (Menux.LuxMenu["WD"].Cast<CheckBox>().CurrentValue)
            {
                new Circle { Color = System.Drawing.Color.LightGreen, Radius = E.Range, BorderWidth = 4f }.Draw
                    (Player.Instance.Position);
            }
            if (Menux.LuxMenu["ED"].Cast<CheckBox>().CurrentValue)
            {
                new Circle { Color = System.Drawing.Color.LightSkyBlue, Radius = R.Range, BorderWidth = 5f }.Draw
                    (Player.Instance.Position);
            }
            if (Menux.LuxMenu["RD"].Cast<CheckBox>().CurrentValue)
            {
                new Circle { Color = System.Drawing.Color.LightSkyBlue, Radius = R.Range, BorderWidth = 5f }.Draw
                    (Player.Instance.Position);
            }
        }
    }
}
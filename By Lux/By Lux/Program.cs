using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace By_Lux
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Lux) { return; }

            Chat.Print("Version 1.3.0...");
            Chat.Print("Injected Successfully...");

            new SpellsLux();
            new Menux();
            new Drawings();
            new Hit();
            new Modes();

            Drawing.OnDraw += Drawings.OnDraw;
            Game.OnTick += Modes.On_Tick;
            Interrupter.OnInterruptableSpell += Modes.OnInterruptableSpell;
        }
    }
}

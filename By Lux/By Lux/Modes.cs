using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static By_Lux.SpellsLux;
using static By_Lux.DamegeX;
using static By_Lux.Program;
using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Enumerations;
using System.Collections.Generic;
using System.Linq;

namespace By_Lux
{
    internal class Modes
    {
        private static IEnumerable<object> enemies;

        public static AIHeroClient _Player
        {
            get { return ObjectManager.Player; }
        }
        public Modes()
        {
        }

        internal static void On_Tick(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Combo();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                Harass();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                LaneClear();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                JungleClear();
            }
            killSteal();
            WExtetion();
        }

        private static void WExtetion()
        {
            //Em Breve
        }

        internal static void OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            var tragentQ = TargetSelector.GetTarget(Q.Range, DamageType.Mixed);
            if (Menux.LuxMenu["Int"].Cast<CheckBox>().CurrentValue && Q.IsReady() && Q.GetPrediction(tragentQ).HitChance >= HitChance.High)
            {
                if (sender.Distance(_Player.ServerPosition, true) <= Q.Range && Q.GetPrediction(tragentQ).HitChance >= HitChance.High)
                {
                    Q.Cast(tragentQ);
                }
            }
        }

        private static void killSteal()
        {
            if (Menux.LuxMenu["KilR"].Cast<CheckBox>().CurrentValue && SpellsLux.R.IsReady())
            {
                var tragetR = TargetSelector.GetTarget(R.Range, DamageType.Magical);
                if (tragetR == null) return;
                if (R.IsReady())
                {
                    var passiva = tragetR.HasPassive() ? tragetR.GetPassiveDamage() : 0f;
                    var damagerXR = tragetR.GetDamage(SpellSlot.R) + passiva;
                    var predictedHealth = Prediction.Health.GetPrediction(tragetR, R.CastDelay + Game.Ping);

                    if (predictedHealth <= damagerXR)
                    {
                        var predicti = R.GetPrediction(tragetR);
                        if (predicti.HitChancePercent >= 100)
                        {
                            R.Cast(predicti.CastPosition);
                        }
                    }
                    if (Menux.LuxMenu["KilQ"].Cast<CheckBox>().CurrentValue && Q.IsReady())
                    {
                        var tragetQ = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
                        if (tragetQ == null) return;
                        if (Q.IsReady())
                        {
                            var passivaQ = tragetQ.HasPassive() ? tragetQ.GetPassiveDamage() : 0f;
                            var damagerXQ = tragetQ.GetDamage(SpellSlot.Q) + passivaQ;
                            var Health = Prediction.Health.GetPrediction(tragetQ, Q.CastDelay + Game.Ping);

                            if (Health <= damagerXQ)
                            {
                                var preQ = Q.GetPrediction(tragetQ);
                                if (preQ.HitChance >= Hit.HitQ())
                                {
                                    Q.Cast(preQ.CastPosition);
                                }
                            }
                            if (Menux.LuxMenu["KilE"].Cast<CheckBox>().CurrentValue && E.IsReady())
                            {
                                var tragetE = TargetSelector.GetTarget(E.Range, DamageType.Magical);
                                if (tragetE == null) return;
                                if (E.IsReady())
                                {
                                    var passivaE = tragetE.HasPassive() ? tragetE.GetPassiveDamage() : 0f;
                                    var damagerXE = tragetE.GetDamage(SpellSlot.E) + passivaE;
                                    var HealthE = Prediction.Health.GetPrediction(tragetE, E.CastDelay + Game.Ping);

                                    if (Health <= damagerXQ)
                                    {
                                        var preE = E.GetPrediction(tragetE);
                                        if (preE.HitChance >= Hit.HitE())
                                        {
                                            E.Cast(preE.CastPosition);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private static void Combo()
        {
            var QT = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var WT = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            var ET = TargetSelector.GetTarget(E.Range, DamageType.Magical);
            var RTt = TargetSelector.GetTarget(3400, DamageType.Mixed);
            var predq = Q.GetPrediction(QT);

            if (Menux.LuxMenu["Co"].Cast<CheckBox>().CurrentValue && Q.IsReady() && QT.IsValidTarget(Q.Range) && Q.GetPrediction(QT).HitChance >= Hit.HitQ())
            {
                Q.Cast(predq.CastPosition);
            }

            if (Menux.LuxMenu["Co"].Cast<CheckBox>().CurrentValue && E.IsReady() && ET.IsValidTarget(E.Range) && E.GetPrediction(ET).HitChance >= Hit.HitE())
            {
                E.Cast(ET);
            }

            if (Player.HasBuff("fanLux"))
            {

                {
                    E.Cast();
                }
            }

            if (Menux.LuxMenu["Co"].Cast<CheckBox>().CurrentValue && R.IsReady() && RTt.IsValidTarget(R.Range))
            {
                foreach (var ultenemies in enemies)
                {
                    var useR = Menux.LuxMenu["Co"].Cast<CheckBox>().CurrentValue;
                    var predictedHealth = Prediction.Health.GetPrediction(RTt, R.CastDelay + Game.Ping);
                    var passiveDamage = RTt.HasPassive() ? RTt.GetPassiveDamage() : 0f;
                    var rDamage = RTt.GetDamage(SpellSlot.R) + passiveDamage;
                    {
                        if ((useR) && (predictedHealth <= rDamage))
                        {
                            R.Cast();
                        }
                        else if (R.IsReady())
                        {

                            var totalDamage = ET.GetDamage(SpellSlot.E) + RTt.GetDamage(SpellSlot.R) + passiveDamage;


                            if (predictedHealth <= totalDamage)
                            {
                                R.Cast();
                            }
                        }
                    }
                }
            }
            if (Menux.LuxMenu["Co"].Cast<CheckBox>().CurrentValue && W.IsReady() && (Player.Instance.HealthPercent <= Menux.LuxMenu["USeHet"].Cast<Slider>().CurrentValue))
            {
                W.Cast(WT.Position);
            }
        }

        private static void Harass()
        {
            var QTH = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var ETH = TargetSelector.GetTarget(E.Range, DamageType.Magical);

            if (Menux.LuxMenu["Co"].Cast<CheckBox>().CurrentValue)
            {
                if (Menux.LuxMenu["Co"].Cast<CheckBox>().CurrentValue && Q.IsReady())
                {
                    var predq = Q.GetPrediction(QTH);
                    if (predq.HitChance >= HitChance.High)
                    {
                        Q.Cast(predq.CastPosition);
                    }
                }

                if (Menux.LuxMenu["Co"].Cast<CheckBox>().CurrentValue && E.IsReady())
                {
                    var prede = E.GetPrediction(ETH);
                    if (prede.HitChance >= HitChance.High)
                    {
                        E.Cast(prede.CastPosition);
                    }
                }
            }
        }

        private static void LaneClear()
        {
            var enemyvisT = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, E.Range, true).Count();
            if (enemyvisT == 0) return;
            var seson3 = EntityManager.MinionsAndMonsters.GetLaneMinions().OrderBy(a => a.MaxHealth).FirstOrDefault(a => a.IsValidTarget(Q.Range));
            if (seson3 == null || seson3.IsInvulnerable || seson3.MagicImmune)
            {
                return;
            }

            if (Menux.LuxMenu["Le"].Cast<CheckBox>().CurrentValue && E.IsReady() && Menux.LuxMenu["MinionE"].Cast<Slider>().CurrentValue <= enemyvisT)
            {
                E.Cast(seson3);
                return;
            }

            if (Menux.LuxMenu["Le"].Cast<CheckBox>().CurrentValue && Q.IsReady())
            {
                Q.Cast();
            }
        }


        private static void JungleClear()
        {
            var target = EntityManager.MinionsAndMonsters.GetJungleMonsters().OrderByDescending(a => a.MaxHealth).FirstOrDefault(a => a.IsValidTarget(900));
            if (Menux.LuxMenu["Ju"].Cast<CheckBox>().CurrentValue && E.IsReady())
            {
                E.Cast(target);
            }
        }
    }
}


using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace EnhancedDevelopment.SafeTraps.Detours
{
    internal class _Building_Trap : RimWorld.Building_Trap
    {
        private List<Pawn> touchingPawns = new List<Pawn>();

        protected virtual float _SpringChance(Pawn p)
        {
            Log.Message("Custom Spring Chance");
            if (p.Faction.IsPlayer)
            {
                return 0.0f;
            }

            float num = (!this.KnowsOfTrap(p) ? StatExtension.GetStatValue((Thing)this, StatDefOf.TrapSpringChance, true) : 0.025f) * GenMath.LerpDouble(0.4f, 0.8f, 0.0f, 1f, p.BodySize);
            if (p.RaceProps.Animal)
                num *= 0.1f;
            return Mathf.Clamp01(num);
        }

        //private void _Spring(Pawn p)
        //{
        //    Log.Message("Custom Spring");
        //    SoundStarter.PlayOneShot(SoundDef.Named("DeadfallSpring"), (SoundInfo)this.Position);

        //    if (p.Faction != null)
        //    {
        //        p.Faction.TacticalMemory.TrapRevealed(this.Position);
        //    }

        //    this.SpringSub(p);


        //}

        //private void _Tick()
        //{
        //    base.Tick();
        //    if (this.Armed)
        //    {
        //        List<Thing> thingList = GridsUtility.GetThingList(this.Position);
        //        for (int index = 0; index < thingList.Count; ++index)
        //        {
        //            Pawn p = thingList[index] as Pawn;
        //            if (p != null && !this.touchingPawns.Contains(p))
        //            {
        //                this.touchingPawns.Add(p);
        //                this.CheckSpring(p);
        //            }
        //        }
        //    }
        //    for (int index = 0; index < this.touchingPawns.Count; ++index)
        //    {
        //        Pawn pawn = this.touchingPawns[index];
        //        if (!pawn.Spawned || pawn.Position != this.Position)
        //            this.touchingPawns.Remove(pawn);
        //    }
        //}

        protected override void SpringSub(Pawn p)
        {
            throw new NotImplementedException();
        }

        //private void CheckSpring(Pawn p)
        //{

        //    Log.Message("Custom CheckSpring");

        //    if ((double)Rand.Value >= (double)this.SpringChance(p))
        //        return;
        //    if (! p.Faction.IsPlayer)
        //    {
        //        this.Spring(p);
        //    }
        //    if (p.Faction !=  Faction.OfPlayer && p.HostFaction != Faction.OfPlayer)
        //        return;
        //    Find.LetterStack.ReceiveLetter(new Letter(Translator.Translate("LetterFriendlyTrapSprungLabel", (object)p.NameStringShort), Translator.Translate("LetterFriendlyTrapSprung", (object)p.NameStringShort), LetterType.BadNonUrgent, (TargetInfo)this.Position), (string)null);
        //}

    }
}

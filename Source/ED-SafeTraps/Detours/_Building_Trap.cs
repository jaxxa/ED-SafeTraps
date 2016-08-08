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
            //Log.Message("Custom Spring Chance");

            if (p.Faction != null)
            {
                if (p.Faction.IsPlayer)
                {
                    return 0.0f;
                }
            }

            float num = (!this.KnowsOfTrap(p) ? StatExtension.GetStatValue((Thing)this, StatDefOf.TrapSpringChance, true) : 0.025f) * GenMath.LerpDouble(0.4f, 0.8f, 0.0f, 1f, p.BodySize);
            if (p.RaceProps.Animal)
                num *= 0.1f;
            return Mathf.Clamp01(num);
        }
        

        protected override void SpringSub(Pawn p)
        {
            throw new NotImplementedException();
        }
        

    }
}

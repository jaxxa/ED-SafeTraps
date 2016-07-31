using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Verse;

namespace EnhancedDevelopment.SafeTraps
{
    class DetourInjector : CommunityCoreLibrary.SpecialInjector
    {
        public override bool Inject()
        {

            // -------------------------------- Detour RimWorld.Building_Trap._SpringChance ------------------------------------

            Log.Message("RimWorld.Building_Trap._SpringChance.");
            MethodInfo RimWorld_Building_Trap = typeof(RimWorld.Building_Trap).GetMethod("SpringChance", BindingFlags.NonPublic | BindingFlags.Instance);
            this.LogNULL(RimWorld_Building_Trap, "RimWorld_Building_Trap");
            
            Log.Message("ED_Building_Trap.");
            MethodInfo ED_Building_Trap = typeof(EnhancedDevelopment.SafeTraps.Detours._Building_Trap).GetMethod("_SpringChance", BindingFlags.NonPublic | BindingFlags.Instance);
            this.LogNULL(ED_Building_Trap, "ED_Building_Trap");

            Log.Message("TryDetourFromTo.");
            if (!CommunityCoreLibrary.Detours.TryDetourFromTo(RimWorld_Building_Trap, ED_Building_Trap))
            {
                return false;
            }

            Log.Message("Enhanced_Development.SafeTraps.DetourInjector.Inject() Compleated.");

            return true;
        }


        private void LogNULL(object objectToTest, String name, bool logSucess = false)
        {
            if (objectToTest == null)
            {
                Log.Error(name + " Is NULL.");
            }
            else
            {
                if (logSucess)
                {
                    Log.Message(name + " Is Not NULL.");
                }
            }
        }
    }
}

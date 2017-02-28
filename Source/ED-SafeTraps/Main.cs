using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Verse;

namespace EnhancedDevelopment.SafeTraps.Detours
{

    [StaticConstructorOnStartup]
    class Main
    {
        static Main()
        {
            Log.Message("SafeTraps, Starting Patching.");

            //var harmony = HarmonyInstance.Create("com.company.project.product");
            //var original = typeof(TheClass).GetMethod("TheMethod");
            //var prefix = typeof(MyPatchClass1).GetMethod("SomeMethod");
            //var postfix = typeof(MyPatchClass2).GetMethod("SomeMethod");
            //harmony.Patch(original, new HarmonyMethod(prefix), new HarmonyMethod(postfix));

            var harmony = HarmonyInstance.Create("Jaxxa.EnhancedDevelopment.SafeTraps");
            //harmony.PatchAll(Assembly.GetExecutingAssembly());

            //Get the Resting Property Getter Method
            MethodInfo RimWorld_BuildingTrap_CheckSpring = typeof(RimWorld.Building_Trap).GetMethod("CheckSpring", BindingFlags.NonPublic | BindingFlags.Instance);
            Main.LogNULL(RimWorld_BuildingTrap_CheckSpring, "RimWorld_BuildingTrap_CheckSpring", false);

            //Get the Prefix Patch
            var prefix = typeof(SpringTrapPatcher).GetMethod("Prefix", BindingFlags.Public | BindingFlags.Static);
            Main.LogNULL(prefix, "Prefix", false);

            //Apply the Prefix Patch
            harmony.Patch(RimWorld_BuildingTrap_CheckSpring, new HarmonyMethod(prefix), null);

            Log.Message("SafeTraps, Finished Patching.");
        }


        /// <summary>
        /// Debug Logging Helper
        /// </summary>
        /// <param name="objectToTest"></param>
        /// <param name="name"></param>
        /// <param name="logSucess"></param>
        private static void LogNULL(object objectToTest, String name, bool logSucess = false)
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

        //[HarmonyPatch(typeof(Plant))]
        //[HarmonyPatch("Add")]
        //[HarmonyPatch("Resting_Getter")]
        static class SpringTrapPatcher
        {

            // prefix
            // - wants instance, result and count
            // - wants to change count
            // - returns a boolean that controls if original is executed (true) or not (false)
            public static Boolean Prefix(Pawn p)
            {
                //Write to log to debug id the patch is running.
                Log.Message("Prefix Running");

                Main.LogNULL(p, "Prefix Pawn", true);

                if (p == null) { return true; }

                if (p.Faction == null) { return true; }

                //Retuen False so the origional method is not executed.
                if (p.Faction.IsPlayer)
                {
                    Log.Message("Return False");
                    return false;
                }
                
                return true;
            }

        }

    }
}

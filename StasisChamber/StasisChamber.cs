using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



namespace StasisChamber
{
    public class StasisChamber : PartModule
    {
        public List<ProtoCrewMember> Crew = FlightGlobals.ActiveVessel.GetVesselCrew();
        [KSPEvent(guiActive = true, guiName = "FreezeCrew", active = true, name = "FreezeCrew")]
        public void FreezeCrew()
        {
            this.vessel.DespawnCrew();
            Events["FreezeCrew"].active = false;
            Events["UnFreezeCrew"].active = true;
            #if DEBUG
                Debug.Log("Crew Frozen/DeSpawned.");
            #endif
        }

        [KSPEvent(guiActive = true, guiName = "UnFreezeCrew", active = false, name = "UnFreezeCrew")]
        public void UnFreezeCrew()
        {
            vessel.SpawnCrew();
            Events["UnFreezeCrew"].active = false;
            Events["FreezeCrew"].active = true;
            #if DEBUG
                Debug.Log("Crew UnFrozen/Spawned.");
            #endif
        }
    }











#if false
        //This will kick us into the save called default and set the first vessel active
        [KSPAddon(KSPAddon.Startup.MainMenu, false)]
        public class Debug_AutoLoadPersistentSaveOnStartup : MonoBehaviour
        {
            //use this variable for first run to avoid the issue with when this is true and multiple addons use it
            public static bool first = true;
            public void Start()
            {
                //only do it on the first entry to the menu
                if (first)
                {
                    first = false;
                    HighLogic.SaveFolder = "default";
                    Game game = GamePersistence.LoadGame("persistent", HighLogic.SaveFolder, true, false);

                    if (game != null && game.flightState != null && game.compatible)
                    {
                        Int32 FirstVessel;
                        Boolean blnFoundVessel = false;
                        for (FirstVessel = 0; FirstVessel < game.flightState.protoVessels.Count; FirstVessel++)
                        {
                            //This logic finds the first non-asteroid vessel
                            if (game.flightState.protoVessels[FirstVessel].vesselType != VesselType.SpaceObject &&
                                game.flightState.protoVessels[FirstVessel].vesselType != VesselType.Unknown)
                            {
                                ////////////////////////////////////////////////////
                                ////////PUT ANY OTHER LOGIC YOU WANT IN HERE////////
                                ////////////////////////////////////////////////////
                                blnFoundVessel = true;
                                break;
                            }
                        }
                        if (!blnFoundVessel)
                        {
                            FirstVessel = 0;
                            FlightDriver.StartAndFocusVessel(game, FirstVessel);
                        }
                    }

                    //CheatOptions.InfiniteFuel = true;
                }
            }
        }
#endif

}

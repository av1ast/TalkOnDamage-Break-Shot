using Rocket.API;
using System.Collections.Generic;
using Bootleg_Gritos.Entities;

namespace Bootleg_Gritos
{
    public class Config : IRocketPluginConfiguration
    {
        public bool HasStartBleedingEffects { get; set; }

        public List<Effects> StartBleedingEffects = new List<Effects>();
        public int StartBleedingRadius { get; set; }
        public bool HasWhileBleedingEffects { get; set; }
        public List<Effects> WhileBleedingEffects = new List<Effects>();
        public int WhileBleedingRadius { get; set; }
        public double WhileBleedingIntervals { get; set; }
        public bool HasStopBleedingEffects { get; set; }
        public int StopBleedingRadius { get; set; }
        public List<Effects> StopBleedingEffects = new List<Effects>();
        public bool HasStartBreakLegEffects { get; set; }
        public List<Effects> StartBreakLegEffects = new List<Effects>();
        public int StartBreakLegRadius { get; set; }
        public bool HasWhileBreakLegEffects { get; set; }
        public List<Effects> WhileBreakLegEffects = new List<Effects>();
        public int WhileBreakLegRadius { get; set; }
        public double WhileBreakLegIntervals { get; set; }
        public bool HasStopBreakLegEffects { get; set; }
        public int StopBreakLegRadius { get; set; }
        public List<Effects> StopBreakLegEffects = new List<Effects>();
        public bool HasStartGunShotEffects { get; set; }
        public List<Effects> StartGunShotEffects = new List<Effects>();
        public int StartGunShotRadius { get; set; }
        public void LoadDefaults()
        {
            HasStartBleedingEffects = true;
            StartBleedingRadius = 50;
            StartBleedingEffects.Add(new Effects(54110));
            HasWhileBleedingEffects = true;
            WhileBleedingRadius = 50;
            WhileBleedingIntervals = 30;
            WhileBleedingEffects.Add(new Effects(5411));
            HasStopBleedingEffects = true;
            StopBleedingRadius = 50;
            StopBleedingEffects.Add(new Effects(5411));
            HasStartBreakLegEffects = true;
            StartBreakLegRadius = 50;
            StartBreakLegEffects.Add(new Effects(5411));
            HasWhileBreakLegEffects = true;
            WhileBreakLegRadius = 50;
            WhileBreakLegIntervals = 30;
            WhileBreakLegEffects.Add(new Effects(5411));
            HasStopBreakLegEffects = true;
            StopBreakLegRadius = 50;
            StopBreakLegEffects.Add(new Effects(5411));
            HasStartGunShotEffects = true;
            StartGunShotRadius = 50;
            StartGunShotEffects.Add(new Effects(5411));
        }
    }
}

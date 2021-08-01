using Rocket.API;
using System.Collections.Generic;
using Bootleg_Gritos.Entities;

namespace Bootleg_Gritos
{
    public class Config : IRocketPluginConfiguration
    {
        public string Div { get; set; }
        public List<Effects> StartBleedingEffects = new List<Effects>();
        public int StartBleedingRadius { get; set; }
        public int StopBleedingRadius { get; set; }
        public List<Effects> StopBleedingEffects = new List<Effects>();
        public List<Effects> StartBreakLegEffects = new List<Effects>();
        public int StartBreakLegRadius { get; set; }
        public bool WhenProneDequipWeapon { get; set; }
        public bool Whenshootedonhanddropweapon { get; set; }
        public bool Breakfootonshootfoots { get; set; }
        public bool Movementmodifiywhenshootfoots { get; set; }
        public float Movementmodifiershotfoots { get; set; }
        public float HallucinationNVL { get; set; }
        public bool DamageClothsWhengetbullets { get; set; }
        public bool WhenGetShotHeadHallucination { get; set; }
        public int ShotUiTimer { get; set; }
        public int DamageClothsWhengetbulletsAmount { get; set; }
        public bool DropHatWhenGetShot { get; set; }
        public int StopBreakLegRadius { get; set; }
        public List<Effects> StopBreakLegEffects = new List<Effects>();
        public List<Effects> StartGunShotEffects = new List<Effects>();
        public List<UIEffects> StartGunShotEffectsUI = new List<UIEffects>();
        public List<UIEffects> StartBleedingEffectsUI = new List<UIEffects>();
        public List<UIEffects> StartBreakLegEffectsUI = new List<UIEffects>();
        public byte StartGunShotRadius { get; set; }
        public void LoadDefaults()
        {
            Div = "Audio/UI Effects";
            StartBleedingRadius = 50;
            StartBleedingEffects.Add(new Effects(54110));
            StopBleedingRadius = 50;
            StopBleedingEffects.Add(new Effects(5411));
            StartBreakLegRadius = 50;
            StartBreakLegEffects.Add(new Effects(5411));
            StopBreakLegRadius = 50;
            StopBreakLegEffects.Add(new Effects(5411));
            StartGunShotRadius = 50;
            StartGunShotEffects.Add(new Effects(5411));
            ShotUiTimer = 10;
            StartBreakLegEffectsUI.Add(new UIEffects(5411));
            StartBleedingEffectsUI.Add(new UIEffects(5411));
            StartGunShotEffectsUI.Add(new UIEffects(5411));
            Div = "Functions Booleans";
            WhenProneDequipWeapon = true;
        }
    }
}

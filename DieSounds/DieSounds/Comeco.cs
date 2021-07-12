using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Rocket.Unturned.Events;
using Rocket.Core.Logging;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;
using System.Threading.Tasks;
using SDG.NetTransport;
using Rocket.Unturned.Chat;

namespace Bootleg_Gritos
{
    public class Mun : RocketPlugin<Config>
    {
        public static Mun Instance { get; set; }
        protected override void Load()
        {
            Instance = this;
            Logger.Log("         Carregado", System.ConsoleColor.DarkRed);
            Logger.Log("------------------------------", System.ConsoleColor.DarkRed);
            Logger.Log("|                             |", System.ConsoleColor.DarkRed);
            Logger.Log("|      By: CommunistDog       |", System.ConsoleColor.DarkRed);
            Logger.Log("|     SoundEffect Plugins     |", System.ConsoleColor.DarkRed);
            Logger.Log("|                             |", System.ConsoleColor.DarkRed);
            Logger.Log("------------------------------", System.ConsoleColor.DarkRed);
            Logger.Log("         Carregado", System.ConsoleColor.DarkRed);
            UnturnedPlayerEvents.OnPlayerUpdateBleeding += UnturnedPlayerEvents_OnPlayerUpdateBleeding;
            UnturnedPlayerEvents.OnPlayerUpdateBroken += UnturnedPlayerEvents_OnPlayerUpdateBroken;
            UseableGun.onBulletHit += UseableGun_onBulletHit;
        }

        private void UseableGun_onBulletHit(UseableGun gun, BulletInfo bullet, InputInfo hit, ref bool shouldAllow)
        {
            System.Random rnd = new System.Random();
            int Index = rnd.Next(0, Mun.Instance.Configuration.Instance.StartGunShotEffects.Count - 1);
            EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StartBreakLegEffects[Index].Effect, Mun.Instance.Configuration.Instance.StartBreakLegRadius, new Vector3(hit.player.movement.region_x, hit.player.movement.region_y));
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateBroken(UnturnedPlayer player, bool broken)
        {
            if (broken == true && Mun.Instance.Configuration.Instance.HasStartBreakLegEffects == true)
            {
                System.Random rnd = new System.Random();
                int Index = rnd.Next(0, Mun.Instance.Configuration.Instance.StartBreakLegEffects.Count - 1);
                EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StartBreakLegEffects[Index].Effect, Mun.Instance.Configuration.Instance.StartBreakLegRadius, player.Position);
            }
            else if (broken == false && Mun.Instance.Configuration.Instance.HasStopBreakLegEffects == true)
            {
                System.Random rnd = new System.Random();
                int Index = rnd.Next(0, Mun.Instance.Configuration.Instance.StopBreakLegEffects.Count - 1);
                EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StopBreakLegEffects[Index].Effect, Mun.Instance.Configuration.Instance.StopBreakLegRadius, player.Position);

            }
            else if (broken == true && Mun.Instance.Configuration.Instance.HasWhileBreakLegEffects == true)
            {
                while (broken == true)
                {
                    System.Random rnd = new System.Random();
                    int Index = rnd.Next(0, Mun.Instance.Configuration.Instance.WhileBreakLegEffects.Count - 1);
                    Task.Delay((int)Mun.Instance.Configuration.Instance.WhileBreakLegIntervals * 1000);
                    EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StartBreakLegEffects[Index].Effect, Mun.Instance.Configuration.Instance.WhileBreakLegRadius, player.Position);
                }

            }
            else
            {

            }
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateBleeding(UnturnedPlayer player, bool bleeding)
        {
            EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StartBleedingEffects[0].Effect, Mun.Instance.Configuration.Instance.StopBleedingRadius, player.Position);
            if (bleeding == true && Mun.Instance.Configuration.Instance.HasStartBleedingEffects == true)
            {
                System.Random rnd = new System.Random();
                int Index = rnd.Next(0, Mun.Instance.Configuration.Instance.StartBleedingEffects.Count - 1);
                EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StartBleedingEffects[Index].Effect, Mun.Instance.Configuration.Instance.StartBleedingRadius, player.Position);
            }
            else if (bleeding == false && Mun.Instance.Configuration.Instance.HasStopBleedingEffects == true)
            {
                System.Random rnd = new System.Random();
                int Index = rnd.Next(0, Mun.Instance.Configuration.Instance.StopBleedingEffects.Count - 1);
                EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StartBleedingEffects[Index].Effect, Mun.Instance.Configuration.Instance.StopBleedingRadius, player.Position);

            }
            else if (bleeding == true && Mun.Instance.Configuration.Instance.HasWhileBleedingEffects == true)
            {
                while (bleeding == true)
                {
                    System.Random rnd = new System.Random();
                    int Index = rnd.Next(0, Mun.Instance.Configuration.Instance.WhileBleedingEffects.Count - 1);
                    Task.Delay((int)Mun.Instance.Configuration.Instance.WhileBleedingIntervals * 1000);
                    EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StartBleedingEffects[Index].Effect, Mun.Instance.Configuration.Instance.WhileBleedingRadius, player.Position);
                }

            }
            else
            {

            }
        }

        protected override void Unload()
        {
            Logger.Log("         Descarregado", System.ConsoleColor.DarkRed);
            Logger.Log("------------------------------", System.ConsoleColor.DarkRed);
            Logger.Log("|                             |", System.ConsoleColor.DarkRed);
            Logger.Log("|      By: CommunistDog       |", System.ConsoleColor.DarkRed);
            Logger.Log("|     SoundEffect Plugins     |", System.ConsoleColor.DarkRed);
            Logger.Log("|                             |", System.ConsoleColor.DarkRed);
            Logger.Log("------------------------------", System.ConsoleColor.DarkRed);
            Logger.Log("         Descarregado", System.ConsoleColor.DarkRed);
            UnturnedPlayerEvents.OnPlayerUpdateBleeding -= UnturnedPlayerEvents_OnPlayerUpdateBleeding;
            UnturnedPlayerEvents.OnPlayerUpdateBroken -= UnturnedPlayerEvents_OnPlayerUpdateBroken;
            UseableGun.onBulletHit -= UseableGun_onBulletHit;
        }
    }
}

using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Rocket.Unturned.Events;
using Rocket.Core.Logging;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;
using System.Threading.Tasks;
using SDG.NetTransport;
using System.Collections.Generic;
using Rocket.Unturned.Chat;
using Bootleg_Gritos.Entities;
using Rocket.Unturned;
using System;
using System.Collections;

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
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;
            UseableGun.onBulletHit += UseableGun_onBulletHit;
        }

        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            player.Player.stance.onStanceUpdated += () => onStanceUpdated(player);
        }
        private void onStanceUpdated(UnturnedPlayer player)
        {
            if (player.Stance == EPlayerStance.PRONE && Mun.Instance.Configuration.Instance.WhenProneDequipWeapon == true)
            {
                player.Player.equipment.dequip();
            }
            var a =  player.Player.stance.initialStance;
            if(a == EPlayerStance.PRONE && Mun.Instance.Configuration.Instance.WhenProneDequipWeapon == true)
            {
                player.Player.equipment.dequip();
            }
        }

        private void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            player.Player.stance.onStanceUpdated -= () => onStanceUpdated(player);
        }

        private void UseableGun_onBulletHit(UseableGun gun, BulletInfo bullet, InputInfo hit, ref bool shouldAllow)
        {
            UnturnedPlayer Puer = null;
            try
            {
                Puer = UnturnedPlayer.FromPlayer(hit.player); 
            }
            catch (Exception)
            {
                shouldAllow = true;
                return;
            }
            int num = (Mun.Instance.Configuration.Instance.StartGunShotEffects != null) ? 1 : 0;
            System.Random rnd = new System.Random();
            int Index1 = rnd.Next(0, Mun.Instance.Configuration.Instance.StartGunShotEffects.Count - num);
            EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StartGunShotEffects[Index1].Effect, Mun.Instance.Configuration.Instance.StartGunShotRadius, Puer.Position);
            int num1 = (Mun.Instance.Configuration.Instance.StartGunShotEffectsUI != null) ? 1 : 0;
            int Index = rnd.Next(0, Mun.Instance.Configuration.Instance.StartGunShotEffectsUI.Count - num1);
            EffectManager.sendUIEffect((ushort)Mun.Instance.Configuration.Instance.StartBreakLegEffectsUI[Index].Effect, 5000, Provider.findTransportConnection(Puer.CSteamID), true, "Argumento");
            StartCoroutine(Wait((ushort)Mun.Instance.Configuration.Instance.StartBreakLegEffectsUI[Index].Effect, Puer, Mun.Instance.Configuration.Instance.ShotUiTimer));
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateBroken(UnturnedPlayer player, bool broken)
        {
            int Index = 0;
            if (broken == true)
            {
                int num = (Mun.Instance.Configuration.Instance.StartBreakLegEffects != null) ? 1 : 0;
                System.Random rnd = new System.Random();
                int Index1 = rnd.Next(0, Mun.Instance.Configuration.Instance.StartBreakLegEffects.Count - num);
                EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StartBreakLegEffects[Index].Effect, Mun.Instance.Configuration.Instance.StartBreakLegRadius, player.Position);
                int num1 = (Mun.Instance.Configuration.Instance.StartBreakLegEffectsUI != null) ? 1 : 0;
                Index = rnd.Next(0, Mun.Instance.Configuration.Instance.StartBreakLegEffectsUI.Count - num1);
                EffectManager.sendUIEffect((ushort)Mun.Instance.Configuration.Instance.StartBreakLegEffectsUI[Index].Effect, 5000, Provider.findTransportConnection(player.CSteamID), true, "Argumento");
            }
            else if (broken == false)
            {
                EffectManager.askEffectClearByID((ushort)Mun.Instance.Configuration.Instance.StartBreakLegEffectsUI[Index].Effect, Provider.findTransportConnection(player.CSteamID));
                int num = (Mun.Instance.Configuration.Instance.StopBreakLegEffects != null) ? 1 : 0;
                System.Random rnd = new System.Random();
                int Index1 = rnd.Next(0, Mun.Instance.Configuration.Instance.StopBreakLegEffects.Count - num);
                EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StopBreakLegEffects[Index].Effect, Mun.Instance.Configuration.Instance.StopBreakLegRadius, player.Position);
            }
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateBleeding(UnturnedPlayer player, bool bleeding)
        {
            int Index = 0;
            UnturnedChat.Say("a");
            if (bleeding == true)
            {
                int num = (Mun.Instance.Configuration.Instance.StartBleedingEffects != null) ? 1 : 0;
                System.Random rnd = new System.Random();
                int Index1 = rnd.Next(0, Mun.Instance.Configuration.Instance.StartBleedingEffects.Count - num);
                EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StartBleedingEffects[Index1].Effect, Mun.Instance.Configuration.Instance.StartBleedingRadius, player.Position);
                int num1 = (Mun.Instance.Configuration.Instance.StartBleedingEffectsUI != null) ? 1 : 0;
                Index = rnd.Next(0, Mun.Instance.Configuration.Instance.StartBleedingEffectsUI.Count - num1);
                EffectManager.sendUIEffect((ushort)Mun.Instance.Configuration.Instance.StartBleedingEffectsUI[Index].Effect, 5000, Provider.findTransportConnection(player.CSteamID), true, "Argumento");
            }
            else if (bleeding == false)
            {
                EffectManager.askEffectClearByID((ushort)Mun.Instance.Configuration.Instance.StartBreakLegEffectsUI[Index].Effect, Provider.findTransportConnection(player.CSteamID));
                int num = (Mun.Instance.Configuration.Instance.StopBleedingEffects != null) ? 1 : 0;
                System.Random rnd = new System.Random();
                int Index1 = rnd.Next(0, Mun.Instance.Configuration.Instance.StopBleedingEffects.Count - num);
                EffectManager.sendEffect((ushort)Mun.Instance.Configuration.Instance.StartBleedingEffects[Index1].Effect, Mun.Instance.Configuration.Instance.StopBleedingRadius, player.Position);
            }
        }
        private IEnumerator Wait(ushort ID, UnturnedPlayer player, int Timer)
        {
            yield return new WaitForSeconds(Timer);
            EffectManager.askEffectClearByID(ID, Provider.findTransportConnection(player.CSteamID));
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
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
            U.Events.OnPlayerDisconnected -= Events_OnPlayerDisconnected;
            UseableGun.onBulletHit -= UseableGun_onBulletHit;
        }
    }
}

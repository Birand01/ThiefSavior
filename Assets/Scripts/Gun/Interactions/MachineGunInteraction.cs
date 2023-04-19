using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunInteraction : InteractionBase
{
    public delegate void OnGunEnableHandler();
    public static event OnGunEnableHandler OnPlayerMachineGunHandler;

    public delegate void OnGunTakeSoundHandler(string name, bool state);
    public static event OnGunTakeSoundHandler OnPlayerGunTakeSoundHandler;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnPlayerGunTakeSoundHandler("GunCollectSound", true);
        OnPlayerMachineGunHandler?.Invoke();
        this.gameObject.SetActive(false);
    }

}

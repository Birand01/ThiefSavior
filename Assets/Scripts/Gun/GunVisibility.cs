using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunVisibility : MonoBehaviour
{
    [SerializeField] private GameObject pistolPrefab, shootButton, machineGunPrefab;
    public delegate void OnEnableGunHandler(GameObject gun);
    public static event OnEnableGunHandler OnEnableGun;

    private void OnEnable()
    {
        MachineGunInteraction.OnPlayerMachineGunHandler += EnableMachineGun;
        PistolInteraction.OnPlayerPistolHandler += EnablePistol;
    }

    private void OnDisable()
    {
        MachineGunInteraction.OnPlayerMachineGunHandler -= EnableMachineGun;
        PistolInteraction.OnPlayerPistolHandler -= EnablePistol;

    }
    private void EnablePistol()
    {
        shootButton.SetActive(true);
        pistolPrefab.SetActive(true);
        machineGunPrefab.SetActive(false);
    }
    private void EnableMachineGun()
    {
        machineGunPrefab.SetActive(true);
        shootButton.SetActive(true);
        pistolPrefab.SetActive(false);
    }
}

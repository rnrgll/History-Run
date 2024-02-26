using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBgmControl : MonoBehaviour
{
    public AudioSource lowEnergybgm;
    public void StartLowEnergyBgm()
    {
        if (!lowEnergybgm.isPlaying)
            lowEnergybgm.Play();
    }
    public void StopLowEnergyBgm()
    {
        if (lowEnergybgm.isPlaying)
            lowEnergybgm.Stop();
    }
}

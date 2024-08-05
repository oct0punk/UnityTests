using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDevice
{
    public float volume { get; set; }
    public int channel { get; set; }
    public bool isEnabled { get; set; }

    public void Disable();

    public void Enable();

    public void SetChannel(int channel);

    public void SetVolume(float percent);
}

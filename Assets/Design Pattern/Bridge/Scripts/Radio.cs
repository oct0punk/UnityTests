using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour, IDevice
{
    public AudioSource source;
    public AudioClip[] clips;

    [SerializeField] bool _toggle;

    public float volume { get; set; }
    public int channel { get; set; }
    public bool isEnabled { get; set; }

    private void Awake()
    {
        if (_toggle)
            Enable();
        else
            Disable();
    }


    public void Disable()
    {
        source.Stop();
        isEnabled = false;
    }

    public void Enable()
    {        
        isEnabled = true;
        SetChannel(channel);
    }

    public void SetChannel(int channel)
    {
        if (!isEnabled) return;
        this.channel = Mathf.Clamp(channel, 0, clips.Length - 1);
        source.clip = clips[this.channel];
        source.Play((ulong)(Time.time % source.clip.length));
    }

    public void SetVolume(float percent)
    {
        if (!isEnabled) return;
        this.volume = Mathf.Clamp01(percent);
        source.volume = this.volume;
    }
}

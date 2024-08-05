using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Television : MonoBehaviour, IDevice
{
    public MeshRenderer mesh;
    [Space]
    public Material[] materials;

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
        mesh.sharedMaterial = materials[0];
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
        this.channel = Mathf.Clamp(channel, 1, materials.Length-1);
        mesh.sharedMaterial = materials[this.channel];
    }

    public void SetVolume(float volume)
    {
        if (!isEnabled) return;
        this.volume = Mathf.Clamp01(volume);
    }
}

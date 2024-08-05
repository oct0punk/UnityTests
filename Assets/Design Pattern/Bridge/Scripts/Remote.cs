using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : MonoBehaviour
{
    public GameObject obj;
    IDevice device;

    private void Awake()
    {
        if (obj.GetComponent<Television>() != null)
        {
            device = obj.GetComponent<Television>();
        }
        else if (obj.GetComponent<Radio>() != null) {
            device = obj.GetComponent<Radio>();
        }
        else
        {
            Debug.Log("Device not set correctly", this);
            gameObject.SetActive(false);
            return;
        }
    }

    public void TogglePower()
    {
        if (device.isEnabled)
            device.Disable();
        else
            device.Enable();
    }

    public void VolumeUp()
    {
        device.SetVolume(device.volume+.1f);
    }
    public void VolumeDown()
    {
        device.SetVolume(device.volume-.1f);
    }

    public void ChannelUp()
    {
        device.SetChannel(device.channel+1);
    }
    public void ChannelDown()
    {
        device.SetChannel(device.channel-1);
    }
}

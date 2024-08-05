using System.Collections;
using UnityEngine;

public class CarFactory : TransportCreator
{
    [Space]
    public CarConfig config;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            (Create() as Car).Init(config);
        }
    }
}
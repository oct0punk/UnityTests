using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFactory : TransportCreator
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Create();
        }
    }
}

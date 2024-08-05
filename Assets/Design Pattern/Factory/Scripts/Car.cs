using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Car : Transport
{
    public MeshRenderer meshRenderer;
    CarConfig _config;


    public void Init(CarConfig config)
    {
        speed =  config.speed;
        meshRenderer.material.color = config.color;
        smoothTime = config.timeToTurn;
        _config = config;
    }

    public override ICloneable DeepClone()
    {
        Car clone = base.DeepClone() as Car;
        return clone;
    }
}

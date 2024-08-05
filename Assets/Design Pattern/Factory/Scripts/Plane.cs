using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : Transport
{
    Vector3 _velocity = Vector3.up;

    public override ICloneable DeepClone()
    {
        Plane clone = base.DeepClone() as Plane;
        clone._velocity = this._velocity;
        return clone;
    }
}

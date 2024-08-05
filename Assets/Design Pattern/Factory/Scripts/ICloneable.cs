using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICloneable
{
    public ICloneable DeepClone();
    public ICloneable ShallowClone();
}
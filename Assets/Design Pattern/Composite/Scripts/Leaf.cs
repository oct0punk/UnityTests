using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Composite
{
    public override void Operation()
    {
        int scaleX = (Random.value * 2) % 2 == 0 ? 1 : -1;
        transform.localScale = new Vector3(
            scaleX / transform.parent.lossyScale.x,
            1.0f/ transform.parent.lossyScale.y,
            1.0f / transform.parent.lossyScale.z);
    }
}

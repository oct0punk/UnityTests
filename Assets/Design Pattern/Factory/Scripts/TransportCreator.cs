using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransport : IProduct
{
    void Deliver();
    void Move();
    void SetTarget(Transform target, TransportCreator creator);
}

public class TransportCreator : AbstractCreator<Transport>
{
    [Space]
    public Transform target;

    public override Transport Create()
    {
        Transport t = base.Create();
        t.SetTarget(target, this);
        return t;
    }


    public void OnDelivered(Transport tr)
    {
        tr.gameObject.SetActive(false);
    }
}

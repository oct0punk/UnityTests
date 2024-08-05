using System.Collections.Generic;
using UnityEngine;

public interface IProduct : ICloneable
{
    public bool isEnabled { get; }
    public void ResetTransform(Transform spawn);
    public void OnSpawn(Transform spawn);
}

public abstract class AbstractCreator<T> : MonoBehaviour where T : IProduct
{
    public T product;
    List<T> pool = new List<T>();
    [Space]
    public Transform spawn;



    public virtual T Create()
    {
        T pooledObject = pool.Find(t => !t.isEnabled);

        if (pooledObject != null)
        {
            pooledObject.ResetTransform(spawn);
            return pooledObject;
        }
        T clone = (T)product.DeepClone();
        clone.OnSpawn(spawn);
        pool.Add(clone);
        return clone;
    }
}

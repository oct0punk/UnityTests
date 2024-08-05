using UnityEngine;

public class Transport : MonoBehaviour, ITransport
{
    protected Transform _target;
    public int speed = 3;

    TransportCreator _creator;
    Vector3 currentVelo;
    [SerializeField] protected float smoothTime = 3;

    public bool isEnabled => gameObject.activeSelf;

    private void FixedUpdate()
    {
        Move();
        if (Vector3.Distance(transform.position, _target.position) < 1)
            Deliver();
    }


    public virtual void Move()
    {
        if (_target != null)
        {
            Vector3 dir = _target.position - transform.position;
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.eulerAngles = new Vector3(
                Mathf.SmoothDampAngle(transform.eulerAngles.x, targetRot.eulerAngles.x, ref currentVelo.x, smoothTime), 
                Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRot.eulerAngles.y, ref currentVelo.y, smoothTime), 
                Mathf.SmoothDampAngle(transform.eulerAngles.z, targetRot.eulerAngles.z, ref currentVelo.z, smoothTime));
        }
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    public virtual void Deliver()
    {
        _creator.OnDelivered(this);
    }

    public void SetTarget(Transform target, TransportCreator creator)
    {
        _target = target;
        _creator = creator;
        enabled = true;
    }

    public virtual ICloneable DeepClone()
    {
        Transport tr = Instantiate(this);
        tr._target = this._target;
        tr.speed = this.speed;
        tr._creator = this._creator;
        tr.currentVelo = this.currentVelo;
        tr.smoothTime = this.smoothTime;
        return tr;
    }

    public virtual ICloneable ShallowClone()
    {
        return Instantiate(this);
    }

    public void ResetTransform(Transform spawn)
    {
        transform.SetPositionAndRotation(spawn.position, spawn.rotation);
        gameObject.SetActive(true);
    }

    public void OnSpawn(Transform spawn)
    {
        ResetTransform(spawn);
    }
}

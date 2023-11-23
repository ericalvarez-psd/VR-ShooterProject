using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public int currentAmmo, maxAmmo, ammoPerShot;
    public float shotRate, range, baseDamage;
    [SerializeField]
    protected List<Transform> bulletSpawnPoints;

    protected bool grabbed = false, shooting = false;
    protected float shotCooldown = 0;
    protected Rigidbody rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //protected virtual void Update() { }

    // FOR TESTING
    float t = 0, tMax = 1;
    protected virtual void Update()
    {
        t += Time.deltaTime;
        if (t > tMax)
        {
            Shoot();
            t = 0;
        }
    }

    public abstract void Shoot();

    public virtual void Grab()
    {
        rb.useGravity = false;
        grabbed = true;
    }

    public virtual void Ungrab()
    {
        rb.useGravity = true;
        grabbed = false;
    }
}

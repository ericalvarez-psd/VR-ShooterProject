using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]

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
    protected AudioSource audioSource;
    [SerializeField]
    protected List<Clip> clips;

    [Header("FOR TESTING")]
    public bool autoShoot;
    [Range(0.2f, 1)]
    public float autoShootTime = 0.2f;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update() 
    {
        if (autoShoot) AutoShoot();
    }

    float t = 0;
    protected virtual void AutoShoot()
    {
        grabbed = true;
        t += Time.deltaTime;
        if (t > autoShootTime)
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

    protected void PlayClip(ClipName name)
    {
        if (clips.Any(c => c.name == name))
        {
            audioSource.clip = clips.First(c => c.name == name).clip;
            audioSource.Play();
        }
    }

    public enum ClipName
    {
        Shoot
    }

    [System.Serializable]
    public struct Clip
    {
        public ClipName name;
        public AudioClip clip;
    }
}


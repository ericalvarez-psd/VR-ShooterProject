using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]

public abstract class Weapon : MonoBehaviour
{
    public const string LEFT_CONTROLLER = "LeftController";
    public const string RIGHT_CONTROLLER = "RightController";

    public int ammoPerShot;
    protected Clip Clip // Stores the clip object with the ammo
    {
        get 
        {
            var clip = GetComponentInChildren<Clip>();
            if (clip == null) clip = new() { ammo = 0 };
            return clip;
        }
    }
    public float shotRate, baseDamage;
    [SerializeField]
    protected List<Transform> bulletSpawnPoints;

    protected bool grabbed = false;

    protected Rigidbody rb;
    protected AudioSource audioSource;
    [SerializeField]
    protected List<AudioClipName> audioClips;

    protected bool CanShoot
    {
        get { return grabbed || autoShoot; }
    }

    [Header("TESTING")]
    public bool autoShoot;
    [Range(0.2f, 1)]
    public float autoShootRate;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update() {}

    public abstract void Shoot();

    public virtual void Grab()
    {
        rb.useGravity = false;
        grabbed = true;
        
        if (transform.parent != null)
        {
            GameCanvasManager.Counter side = GameCanvasManager.Counter.Right;
            if (transform.parent.CompareTag(LEFT_CONTROLLER)) side = GameCanvasManager.Counter.Left;
            if (transform.parent.CompareTag(RIGHT_CONTROLLER)) side = GameCanvasManager.Counter.Right;
            GameCanvasManager.Instance.SetAmmo(Clip.ammo, side);
        }
    }

    public virtual void Ungrab()
    {
        rb.useGravity = true;
        grabbed = false;
        if (transform.parent != null)
        {
            GameCanvasManager.Counter side = GameCanvasManager.Counter.Right;
            if (transform.parent.CompareTag(LEFT_CONTROLLER)) side = GameCanvasManager.Counter.Left;
            if (transform.parent.CompareTag(RIGHT_CONTROLLER)) side = GameCanvasManager.Counter.Right;
            GameCanvasManager.Instance.SetAmmo(0, side);
        }
    }

    public virtual void Reload() 
    {
        if (transform.parent != null)
        {
            GameCanvasManager.Counter side = GameCanvasManager.Counter.Right;
            if (transform.parent.CompareTag(LEFT_CONTROLLER)) side = GameCanvasManager.Counter.Left;
            if (transform.parent.CompareTag(RIGHT_CONTROLLER)) side = GameCanvasManager.Counter.Right;
            GameCanvasManager.Instance.SetAmmo(Clip.ammo, side);
        }
    }

    protected void PlayAudioClip(ClipName name)
    {
        if (audioClips.Any(c => c.name == name))
        {
            audioSource.clip = audioClips.First(c => c.name == name).clip;
            audioSource.Play();
        }
    }

    public enum ClipName
    {
        Shoot
    }

    [System.Serializable]
    public struct AudioClipName
    {
        public ClipName name;
        public AudioClip clip;
    }
}


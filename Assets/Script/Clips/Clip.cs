using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds an ammount of a specific type of ammo and offers funcionality for taking ammo from it.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Clip : MonoBehaviour
{
    public bool InUse
    {
        get
        {
            return transform.parent != null;
        }
    }
    Rigidbody rb;

    public int ammo;
    public GameObject ammoType;
    public readonly float lifeTime;

    public bool HasAmmo
    {
        get { return ammo > 0; }
    }

    void Start() { rb = GetComponent<Rigidbody>(); }

    void Update() { rb.useGravity = !InUse; }

    /// <summary>
    /// Attaches the clip to the gun passe
    /// </summary>
    public void Attach(GameObject weapon)
    {
        if (weapon != null) 
        {
            transform.parent = weapon.transform;
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            weapon.GetComponent<Weapon>().Reload();
        }
    }

    /// <summary>
    /// Removes from the clip the specified ammount of ammo.
    /// </summary>
    /// <param name="ammount">Ammount of ammo to remove.</param>
    public void RemoveAmmo(int ammount)
    {
        ammo -= ammount;
        if (ammo < 1) ammo = 0;
    }

    /// <summary>
    /// Applies gravity to the clip and destroys it when its lifetime is over.
    /// </summary>
    public void DropClip()
    {
        transform.parent = null;
        Destroy(gameObject, lifeTime);
    }
}

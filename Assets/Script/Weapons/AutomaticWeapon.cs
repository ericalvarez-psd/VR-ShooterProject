using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AutomaticWeapon : Weapon
{
    public virtual void StartShooting()
    {
        shooting = true;
    }

    public virtual void StopShooting()
    {
        shooting = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : Weapon
{
    public override void Shoot()
    {
        if (grabbed && currentAmmo > 0)
        {
            Transform spawnPoint = bulletSpawnPoints[0];
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation, spawnPoint);
        }
    }
}

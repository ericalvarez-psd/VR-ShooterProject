using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : AutomaticWeapon
{
    protected override void Update()
    {
        base.Update();
    }

    protected override IEnumerator ShootCoroutine()
    {
        while (shooting)
        {
            Shoot();
            yield return new WaitForSeconds(shotRate);
        }
    }

    public override void Shoot()
    {
        if (grabbed && currentAmmo > 0)
        {
            Transform spawnPoint = bulletSpawnPoints[0];
            if (Instantiate(bullet, spawnPoint.position, spawnPoint.rotation).TryGetComponent(out Bullet b)) b.SetDamage(baseDamage);
            PlayClip(ClipName.Shoot);
            currentAmmo -= ammoPerShot;
        }
    }
}

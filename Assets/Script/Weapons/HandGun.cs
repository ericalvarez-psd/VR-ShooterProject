using UnityEngine;

public class HandGun : Weapon
{
    public override void Shoot()
    {
        if (grabbed && currentAmmo > 0)
        {
            Transform spawnPoint = bulletSpawnPoints[0];
            if (Instantiate(bullet, spawnPoint.position, spawnPoint.rotation).TryGetComponent(out Ammunition b)) b.SetDamage(baseDamage);
            PlayClip(ClipName.Shoot);
            currentAmmo -= ammoPerShot;
        }
    }

    protected override void Update()
    {
        base.Update();
        if (autoShoot) AutoShoot();
    }

    // TESTING
    float t = 0;
    protected virtual void AutoShoot()
    {
        grabbed = true;
        t -= Time.deltaTime;
        if (t <= 0)
        {
            Shoot();
            t = autoShootRate;
        }
    }
}

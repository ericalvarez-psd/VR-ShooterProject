using UnityEngine;

public class Shotgun : Weapon
{
    public int pelletsPerShot;
    public float maxPelletRotationOffset;

    public override void Shoot()
    {
        if (grabbed && currentAmmo > 0)
        {
            Transform spawnPoint = bulletSpawnPoints[0];
            for (int i = 0; i < pelletsPerShot; i++)
            {
                Vector3 rotation = spawnPoint.rotation.eulerAngles;
                float x = Random.Range(-maxPelletRotationOffset, maxPelletRotationOffset);
                float y = Random.Range(-maxPelletRotationOffset, maxPelletRotationOffset);
                if (Instantiate(bullet, spawnPoint.position, Quaternion.Euler(rotation.x + x, rotation.y + y, rotation.z)).TryGetComponent(out Ammunition b)) b.SetDamage(baseDamage);
            }
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

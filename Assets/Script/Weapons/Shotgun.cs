using UnityEngine;

public class Shotgun : Weapon
{
    public int pelletsPerShot;
    public float maxPelletAngleOffset;

    public override void Shoot()
    {
        if (autoShoot && !Clip.HasAmmo)
        {
            autoShoot = false;
            grabbed = false;
        }
        if (CanShoot && Clip.HasAmmo)
        {
            Transform spawnPoint = bulletSpawnPoints[0];
            for (int i = 0; i < pelletsPerShot; i++)
            {
                Vector3 rotation = spawnPoint.rotation.eulerAngles;
                float xOffset = Random.Range(-maxPelletAngleOffset, maxPelletAngleOffset);
                float yOffset = Random.Range(-maxPelletAngleOffset, maxPelletAngleOffset);
                if (Instantiate(Clip.ammoType, spawnPoint.position, Quaternion.Euler(rotation.x + xOffset, rotation.y + yOffset, rotation.z)).TryGetComponent(out Ammunition b)) b.SetDamage(baseDamage);
            }
            PlayAudioClip(ClipName.Shoot);
            Clip.RemoveAmmo(ammoPerShot);
            if (transform.parent != null)
            {
                GameCanvasManager.Counter side = GameCanvasManager.Counter.Right;
                if (transform.parent.CompareTag(LEFT_CONTROLLER)) side = GameCanvasManager.Counter.Left;
                if (transform.parent.CompareTag(RIGHT_CONTROLLER)) side = GameCanvasManager.Counter.Right;
                GameCanvasManager.Instance.SetAmmo(Clip.ammo, side);
            }
        }
        else if (CanShoot && !Clip.HasAmmo)
        {
            Clip.DropClip();
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

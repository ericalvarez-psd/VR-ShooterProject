using System.Collections;
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
        if (autoShoot && !Clip.HasAmmo)
        {
            autoShoot = false;
            grabbed = false;
        }
        if (CanShoot && Clip.HasAmmo)
        {
            Transform spawnPoint = bulletSpawnPoints[0];
            if (Instantiate(Clip.ammoType, spawnPoint.position, spawnPoint.rotation).TryGetComponent(out Ammunition b)) b.SetDamage(baseDamage);
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
}

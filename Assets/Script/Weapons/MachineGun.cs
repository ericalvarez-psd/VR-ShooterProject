using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : AutomaticWeapon
{
    public GameObject hitEffect;

    protected override void Update()
    {
        base.Update();
        shotCooldown -= Time.deltaTime;
        if (shooting && shotCooldown <= 0)
        {
            Shoot();
            shotCooldown = shotRate;
        }
    }

    public override void Shoot()
    {
        if (currentAmmo > 0)
        {
            //Ray ray = new(bulletSpawnPoints[0].position, bulletSpawnPoints[0].forward);
            //Physics.Raycast(ray, out RaycastHit hit, range, damageLayers);
            //if (hit.collider.gameObject.TryGetComponent(out TargetBehaviour target) && target.RemoveHP(baseDamage)) GameManager.Instance.AddScore(1);
            //GameObject hitEff = Instantiate(hitEffect, hit.point, Quaternion.identity);
            //hitEff.transform.localScale = Vector3.one * 0.2f;
            //Destroy(hitEff, 0.2f);
        }
    }
}

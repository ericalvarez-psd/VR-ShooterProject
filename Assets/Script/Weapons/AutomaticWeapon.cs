using System.Collections;

public abstract class AutomaticWeapon : Weapon
{
    private bool _shooting = false;
    public bool shooting
    {
        get
        {
            return _shooting;
        }
        set
        {
            _shooting = value;
            StartCoroutine(ShootCoroutine());
        }
    }

    // TESTING
    bool lastAutoShoot = false;
    protected override void Update()
    {
        base.Update();
        if (lastAutoShoot != autoShoot)
        {
            shooting = autoShoot;
            lastAutoShoot = autoShoot;
        }
    }

    public virtual void StartShooting()
    {
        shooting = true;
    }

    public virtual void StopShooting()
    {
        shooting = false;
    }

    protected abstract IEnumerator ShootCoroutine();
}

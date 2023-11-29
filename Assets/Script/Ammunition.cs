using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ammunition : MonoBehaviour
{
    public float speed, damageMultiplier, lifetime;
    float carriedDamage;
    Rigidbody rb;

    public float FinalDamage
    {
        get { return carriedDamage * damageMultiplier; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = rb.transform.forward * speed;
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.collider.gameObject;
        if (go.CompareTag("Target") && go.TryGetComponent(out TargetBehaviour target)) target.RemoveHP(FinalDamage);
        Destroy(gameObject);
    }

    public void SetDamage(float damage)
    {
        carriedDamage = damage;
    }
}

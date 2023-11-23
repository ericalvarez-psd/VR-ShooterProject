using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public float minSpeed, maxSpeed, ySpeed, maxHP;
    float xSpeed, startY, HP;
    bool movingOnY = true, reachedRange = false;

    void Start()
    {
        HP = maxHP;
        xSpeed = Random.Range(minSpeed, maxSpeed);
        startY = transform.position.y;
    }

    void Update()
    {
        if (!reachedRange && transform.position.y <= startY - 2)
        {
            ChangeDir(false);
            reachedRange = true;
        }
        Move(movingOnY);
    }

    void Move(bool y)
    {
        Vector3 dir = y ? -transform.up : transform.forward;
        float speed = y ? ySpeed : xSpeed;
        transform.position = transform.position + Time.deltaTime * speed * dir ;
    }

    public bool RemoveHP(float ammount)
    {
        HP -= ammount;
        if (HP <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        else return false;
    }

    public void ChangeDir(bool y)
    {
        movingOnY = y;
    }
}

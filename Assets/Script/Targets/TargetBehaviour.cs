using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public bool zMovement = false;
    bool visible = false;
    bool EndReached
    {
        get
        {
            return transform.position.z < TargetManager.endZPos;
        }
    }
    [Range(0, 1)]
    public float zMoveChance = 0.2f;
    public float minSpeed = 5, maxSpeed = 10;
    float xSpeed, ySpeed = 5, zSpeed = 2, startZPos, zDestination, zDistance = 1;
    public int maxHP;
    int HP;

    void Start()
    {
        HP = maxHP;
        xSpeed = Random.Range(minSpeed, maxSpeed);
        startZPos = transform.position.x;
        zDestination = startZPos - zDistance;
    }

    void Update()
    {
        if (EndReached)
        {
            yMove(true);
            return;
        }
        if (visible) xMove();
        else yMove(false);
    }

    void xMove()
    {
        transform.position = transform.position + transform.forward * xSpeed * Time.deltaTime;
        
        //zMove();
    }

    void yMove(bool up)
    {
        float yPos = up ? TargetManager.hideYPos : TargetManager.showYPos;
        bool ended = up ? transform.position.y < yPos : transform.position.y > yPos;
        if (ended)
            transform.position = Vector3
                .MoveTowards(transform.position,
                             new Vector3(transform.position.x, yPos, transform.position.z),
                             ySpeed * Time.deltaTime);
        else if (EndReached) Destroy(gameObject, 3);
        else visible = true;
    }

    void zMove()
    {
        if (zMovement) transform.position = Vector3
                                            .MoveTowards(transform.position,
                                                         new Vector3(transform.position.x, zDestination, transform.position.z),
                                                         zSpeed * Time.deltaTime);
    }

    public bool RemoveHP(int ammount)
    {
        HP -= ammount;
        if (HP <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        else return false;
    }
}

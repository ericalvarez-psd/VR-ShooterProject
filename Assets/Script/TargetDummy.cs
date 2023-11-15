using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    [SerializeField] float yExposed;
    [SerializeField] float yHidden;
    [SerializeField] float timeExposed;

    bool isExposed = true;
    float timer;
   
    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeExposed)
        {
            timer = 0;
            if (isExposed)
            {
                Hide();
            }
            else
            {
                Expose();
            }
        }
    }

    void Hide()
    {
        transform.position = new Vector3(transform.position.x, yHidden, transform.position.z);
        isExposed = false;
    }

    void Expose()
    {
        transform.position = new Vector3(transform.position.x, yExposed, transform.position.z);
        isExposed = true;
    }
}
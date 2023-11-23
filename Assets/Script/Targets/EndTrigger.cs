using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TargetEnd") && transform.parent.gameObject.TryGetComponent(out TargetBehaviour target)) target.ChangeDir(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TargetEnd")) Destroy(transform.parent.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Weapon>(out _) && transform.parent.TryGetComponent(out Clip clip))
            if (!clip.InUse) 
                clip.Attach(other.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableChildrenOnEnter : MonoBehaviour
{
    private void Awake()
    {    
        ToggleChidren(false);
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            ToggleChidren(true);
        }
    }

    private void ToggleChidren(bool state)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(state);
        }
    }

    private void OnValidate()
    {
        Collider collider = GetComponent<Collider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<SphereCollider>();
            ((SphereCollider)collider).radius = 15f;
        }

        collider.isTrigger = true;
    }
}

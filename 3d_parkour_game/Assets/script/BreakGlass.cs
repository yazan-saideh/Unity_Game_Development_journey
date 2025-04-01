using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{
    public GameObject breakableGlass;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
           Instantiate(breakableGlass, gameObject.transform.position, breakableGlass.transform.rotation);
            Destroy(gameObject);
        }
    }
}

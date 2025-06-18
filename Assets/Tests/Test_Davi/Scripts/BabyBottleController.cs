using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBottleController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}

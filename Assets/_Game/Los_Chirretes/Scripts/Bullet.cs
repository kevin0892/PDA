using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Impact"))
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}

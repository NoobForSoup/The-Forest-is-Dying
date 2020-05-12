using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject fireSplat;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponentInParent<Golem>() && !other.GetComponent<Fireball>())
        {
            Instantiate(fireSplat, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.GetComponent<PlayerMovement>())
        {
            FindObjectOfType<PlayerHealth>().Hurt();
        }

        if (other.GetComponent<Repairable>())
        {
            other.GetComponent<Repairable>().Reverse();
        }
    }
}

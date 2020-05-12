using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Repairable>())
        {
            other.GetComponent<Repairable>().Repair();
        }

        if(other.GetComponent<Shield>())
        {
            Destroy(gameObject);
            other.GetComponentInParent<Golem>().Fireball(transform.position);
        }
        else
        if(other.GetComponentInParent<Golem>())
        {
            other.GetComponentInParent<Golem>().ModifyHealth(-10f);
        }

        if(!other.GetComponent<PlayerMovement>())
        {
            Destroy(gameObject);
        }
    }
}

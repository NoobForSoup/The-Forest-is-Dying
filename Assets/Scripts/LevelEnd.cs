using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>())
        {
            other.GetComponent<PlayerMovement>().enabled = false;
            other.GetComponent<SpellHandler>().enabled = false;
            animator.SetTrigger("Open");
        }
    }
}

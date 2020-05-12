using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public GameObject player;
    public Vector3 checkpoint;

    private void Start()
    {
        checkpoint = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>())
        {
            other.GetComponent<PlayerMovement>().respawn = true;
        }
    }
}

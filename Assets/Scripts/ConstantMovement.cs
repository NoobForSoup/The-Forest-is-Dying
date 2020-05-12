using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    public Vector3 movement;

    private void Update()
    {
        transform.position += ((transform.forward * movement.x) + (transform.up * movement.y) + (transform.right * movement.z)) * Time.deltaTime;
    }
}

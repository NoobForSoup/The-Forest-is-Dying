using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    public GameObject magicPrefab;
    public Camera camera;

    public float cooldown;
    public float fireCooldown = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;

            if (cooldown < 0f)
            {
                cooldown = 0f;
            }
        }

        if (Input.GetButtonDown("Fire1") && cooldown <= 0f)
        {
            cooldown = fireCooldown;
            Instantiate(magicPrefab, camera.transform.position + camera.transform.forward, camera.transform.rotation);
        }
    }
}

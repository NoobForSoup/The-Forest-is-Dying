using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golem : MonoBehaviour
{
    public GameObject fireball;

    public Slider slider;
    public Transform player;

    public float currentHealth;
    public float maxHealth = 1000f;

    public float cooldown;
    public float fireCooldown = 5f;

    public bool invulnerable = false;

    public Animator canvas;

    private void Start()
    {
        cooldown = fireCooldown;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        slider.value = currentHealth;
        transform.LookAt(player);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        if(cooldown > 0f)
        {
            cooldown -= Time.deltaTime;

            if (cooldown <= 0f)
            {
                cooldown = fireCooldown;
                GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }

    public void ModifyHealth(float modifier)
    {
        currentHealth += modifier;

        if((currentHealth <= 750 && currentHealth > 725) || (currentHealth <= 500 && currentHealth > 475) || (currentHealth <= 250 && currentHealth > 225))
        {
            GetComponent<Animator>().SetBool("Shield", true);
        }
        else
        if((currentHealth <= 725 && currentHealth > 715) || (currentHealth <= 475 && currentHealth > 465) || (currentHealth <= 225 && currentHealth > 215))
        {
            GetComponent<Animator>().SetBool("Shield", false);
            fireCooldown /= 2;

            foreach(Repairable plant in FindObjectsOfType<Repairable>())
            {
                plant.Reverse();
            }
        }

        if(currentHealth <= 0f)
        {
            FindObjectOfType<PlayerMovement>().enabled = false;
            FindObjectOfType<SpellHandler>().enabled = false;
            canvas.SetTrigger("Open");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Fireball()
    {
        GameObject ball = Instantiate(fireball, transform.position + transform.up * 7f + transform.forward, Quaternion.identity);
        ball.transform.LookAt(player);

        if(currentHealth <= 250)
        {
            ball = Instantiate(fireball, transform.position + transform.up * 7f + transform.forward, Quaternion.identity);
            ball.transform.LookAt(player);
            ball.transform.rotation = Quaternion.Euler(ball.transform.rotation.eulerAngles.x, ball.transform.rotation.eulerAngles.y + 30f, ball.transform.rotation.eulerAngles.z);

            ball = Instantiate(fireball, transform.position + transform.up * 7f + transform.forward, Quaternion.identity);
            ball.transform.LookAt(player);
            ball.transform.rotation = Quaternion.Euler(ball.transform.rotation.eulerAngles.x, ball.transform.rotation.eulerAngles.y - 30f, ball.transform.rotation.eulerAngles.z);
        }
    }

    public void Fireball(Vector3 position)
    {
        GameObject ball = Instantiate(fireball, position, Quaternion.identity);
        ball.transform.LookAt(player);
    }

    public void PlaySound(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}

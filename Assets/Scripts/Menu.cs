using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator canvas;

    public Camera camera;

    private int index = -1;

    public AudioSource click;

    public void Update()
    {
        if (index == -1 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10f))
            {
                if (hit.transform.GetComponent<MenuItem>())
                {
                    click.Play();
                    index = hit.transform.GetComponent<MenuItem>().item;
                    canvas.GetComponent<Animator>().SetTrigger("Open");
                }
            }
        }
    }

    public void HandleOption()
    {
        switch (index)
        {
            case 0:
                LoadScene();
                break;
            case 1:
                ExitGame();
                break;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

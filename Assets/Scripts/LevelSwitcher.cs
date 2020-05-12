using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    static bool died = false;
    public DialogueTrigger bossDialogue;
    public DialogueTrigger bossDeathDialogue;

    public void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            if(died)
            {
                bossDeathDialogue.Dialogue();
            }
            else
            {
                bossDialogue.Dialogue();
            }
        }
    }

    public void NextLevel()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        if(buildIndex == 3 && FindObjectOfType<PlayerHealth>().state == 3)
        {
            died = true;
            SceneManager.LoadScene(buildIndex);
        }
        else
        {
            SceneManager.LoadScene(buildIndex + 1);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

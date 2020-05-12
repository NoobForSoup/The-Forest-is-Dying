using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public float sensitivity = 1f;

    public void Start()
    {
        sensitivity = PlayerPrefs.GetFloat("Sensitivity", 1f);
    }

    public void SetSensitivity(Slider slider)
    {
        sensitivity = slider.value / 10;
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
    }

    public void OnLevelWasLoaded(int level)
    {
        FindObjectOfType<PlayerMovement>().sensitivity = sensitivity;
    }

    public static string GetPlayerInitials(string username)
    {
        string initials = "";
        string[] names = username.Split(' ');

        initials += names[0][0]; //or names[0].Substring(0, 1);
        initials += names[names.Length - 1][0];

        return initials;
        //or "return initials.ToUpper();" for capitalization.
    }
}

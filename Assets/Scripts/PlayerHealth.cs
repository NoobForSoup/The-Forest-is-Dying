using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int state = 0;

    public GameObject overlayLeft;
    public GameObject overlayRight;

    public Animator animator;

    public void Hurt()
    {
        Color color = Color.white;
        color.a = 0.3f;
        Color color2 = Color.white;
        color2.a = 1f;

        state++;
        switch(state)
        {
            case (1):
                overlayLeft.SetActive(true);
                overlayRight.SetActive(true);
                overlayLeft.GetComponent<RawImage>().color = color;
                overlayRight.GetComponent<RawImage>().color = color;
                break;
            case (2):
                overlayLeft.GetComponent<RawImage>().color = color2;
                overlayRight.GetComponent<RawImage>().color = color2;
                break;
            case (3):
                animator.SetTrigger("Open");
                break;
        }
    }
}

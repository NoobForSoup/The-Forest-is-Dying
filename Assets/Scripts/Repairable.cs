using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Repairable : MonoBehaviour
{
    public UnityEvent OnTriggered;
    public UnityEvent OnReverse;

    public void Repair()
    {
        OnTriggered.Invoke();
    }

    public void Reverse()
    {
        OnTriggered.Invoke();
    }
}

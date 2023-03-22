using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnResourcesChange = new UnityEvent();

    public static void ResourceChange()
    {

        OnResourcesChange.Invoke();

    }
}

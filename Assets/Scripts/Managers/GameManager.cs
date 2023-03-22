using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Managers")]
    [SerializeField] private ResourceManager resourceManager;

    public ResourceManager ResourceManager
    {
        get { return resourceManager; }
    }

    private void Awake()
    {

        Instance = this;

    }

    private void Start()
    {

        UIResourceUpdate.Instance.UpdateResourceText();
    }
}

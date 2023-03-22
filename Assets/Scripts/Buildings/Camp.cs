using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : Building
{
    [Header("Resource generation")]
    [SerializeField] private int wood;
    [SerializeField] private int stone;
    [SerializeField] private int food;

    [SerializeField] private float generationRate;
    private float timer;

    private void Update()
    {
        if(isActive)
        {
            BuildingLogic();
        }
        

    }
    private void GenerateResources()
    {

        Debug.Log("Called generate resources!");
        
        GameManager.Instance.ResourceManager.Resources[ResourceManager.ResourceType.Wood] += wood;
        GameManager.Instance.ResourceManager.Resources[ResourceManager.ResourceType.Food] += food;
        GameManager.Instance.ResourceManager.Resources[ResourceManager.ResourceType.Stone] += stone;

        GlobalEventManager.ResourceChange();

    }

    protected override void BuildingLogic()
    {
        timer += Time.deltaTime;

        if (timer >= generationRate)
        {

            timer = 0;
            GenerateResources();

        }
    }

}

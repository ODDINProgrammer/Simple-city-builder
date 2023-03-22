using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public enum ResourceType
    {
        Wood,
        Stone,
        Food
    }

    [HideInInspector]
    public ResourceType Type;

    // Accessor to resources 
    private Dictionary<ResourceType, int> resources;
    public Dictionary<ResourceType, int> Resources
    {
        get { return resources; }

        set { resources = value; }
    }

    private void Start()
    {

        InitializeResources();

        GlobalEventManager.OnResourcesChange.AddListener(DebugResourceChange);

    }

    private void InitializeResources()
    {

        resources = new Dictionary<ResourceType, int>();
        
        resources.Add(ResourceType.Wood, 0);
        resources.Add(ResourceType.Stone, 0);
        resources.Add(ResourceType.Food, 0);

    }

    private void DebugResourceChange()
    {

        Debug.Log("Wood: " + resources[ResourceType.Wood]);
        Debug.Log("Food: " + resources[ResourceType.Food]);
        Debug.Log("Stone: " + resources[ResourceType.Stone]);

    }
}

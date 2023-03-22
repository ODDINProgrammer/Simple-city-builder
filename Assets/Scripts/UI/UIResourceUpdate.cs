using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIResourceUpdate : MonoBehaviour
{
    public static UIResourceUpdate Instance;

    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI stoneText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GlobalEventManager.OnResourcesChange.AddListener(UpdateResourceText);
    }

    public void UpdateResourceText()
    {

        woodText.text = GameManager.Instance.ResourceManager.Resources[ResourceManager.ResourceType.Wood].ToString();
        
        foodText.text = GameManager.Instance.ResourceManager.Resources[ResourceManager.ResourceType.Food].ToString();
        
        stoneText.text = GameManager.Instance.ResourceManager.Resources[ResourceManager.ResourceType.Stone].ToString();
    }
}

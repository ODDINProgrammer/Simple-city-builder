using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Grid : MonoBehaviour
{
    [SerializeField] private TerrainData terrainData;

    private Vector2Int gridSize;

    [SerializeField] private Building flyingBuilding;
    [SerializeField] private LayerMask buildingLayer;

    private RaycastHit hit;
    
    public void StartPlacingBuilding(Building buildingPrefab)
    {

        if(flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }

        flyingBuilding = Instantiate(buildingPrefab);
    }

    private void Awake()
    {
        gridSize.x = (int)terrainData.size.x;
        gridSize.y = (int)terrainData.size.z;
    }


    private void Update()
    {

        DeclineBuilding();
        HouseMouseFollow();
    }

    private void HouseMouseFollow()
    {

        if (flyingBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 5000f, buildingLayer))
            {
                flyingBuilding.transform.position = hit.point;
            }
        }
    }

    private void DeclineBuilding()
    {
        if (Input.GetMouseButtonDown(1))
        {

            if (flyingBuilding != null)
            {
                Destroy(flyingBuilding.gameObject);
                flyingBuilding = null;
            }
        }
    }
}

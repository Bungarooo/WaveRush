using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable = true;
    public bool IsPlaceable{ get { return isPlaceable; } }

    void OnMouseDown()
    {
        if (!isPlaceable)
        {
            return;
        }
        bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
        isPlaceable= !isPlaced;
    }
}

using UnityEngine;

public class BuildingAnchor : MonoBehaviour
{
    private GameObject _currentBuilding;
    private bool _isBusy;

    public bool IsBusy => _isBusy;

    public void PlaceBuilding(GameObject building)
    {
        _currentBuilding = building;
        _isBusy = true;
    }
}

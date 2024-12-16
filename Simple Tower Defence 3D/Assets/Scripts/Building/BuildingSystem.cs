using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    private GameObject _currentObject;

    private readonly List<Transform> Anchors = new List<Transform>();
    private readonly List<GameObject> Buildings = new List<GameObject>();

    private void Start()
    {
        foreach (Transform obj in transform)
        {
            Anchors.Add(obj);
        }
    }

    private void Update()
    {
        if (_currentObject == null)
            return;
        if (Anchors.Count <= 0)
            return;

        Building();
    }

    public void StartBuilding(GameObject building)
    {
        if (_currentObject != null)
            Destroy(_currentObject);
        
        building.transform.SetParent(GetNearestAnchor(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        building.transform.localPosition = new Vector3(0, 1, 0);
        _currentObject = building;
    }
    
    private void Building()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask);

        if (!hit.collider)
            return;

        Vector3 currentPos = new Vector3(hit.point.x, 1, hit.point.z);
        _currentObject.transform.SetParent(GetNearestAnchor(currentPos));
        _currentObject.transform.localPosition = new Vector3(0, 1, 0);

        if (Input.GetMouseButtonDown(0) && MoneyController.Instance.GetMoneyAmount() >= _currentObject.GetComponent<Building>().Price)
            PlaceBuilding();
        if (Input.GetMouseButtonDown(1))
            Destroy(_currentObject);
    }
    
    private void PlaceBuilding()
    {
        Buildings.Add(_currentObject);
        _currentObject.GetComponent<Building>().Place();
        _currentObject.transform.parent.GetComponent<BuildingAnchor>().PlaceBuilding(_currentObject);
        MoneyController.Instance.DecreaseMoney(_currentObject.GetComponent<Building>().Price);
        _currentObject = null;
    }

    public bool IsAvailableAnchors()
    {
        return Anchors.Where(anchor => !anchor.GetComponent<BuildingAnchor>().IsBusy).ToList().Count > 0;
    }

    private Transform GetNearestAnchor(Vector3 position)
    {
        Transform currentAnchor = Anchors[0];

        foreach (Transform anchor in Anchors.Where(anchor =>
                     Vector3.Distance(position, anchor.position) < Vector3.Distance(position, currentAnchor.position) &&
                     !anchor.GetComponent<BuildingAnchor>().IsBusy))
        {
            currentAnchor = anchor;
        }

        return currentAnchor;
    }
}

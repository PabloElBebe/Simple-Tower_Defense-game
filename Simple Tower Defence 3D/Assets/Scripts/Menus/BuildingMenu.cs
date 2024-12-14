using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenu : MonoBehaviour
{
    [SerializeField] private BuildingSystem _buildingSystem;
    
    [Header("Buttons")]
    [SerializeField] private Button _crystalTowerButton;
    [SerializeField] private Button _shardTowerButton;
    [SerializeField] private Button _hexTowerButton;

    [Header("Toggle")]
    [SerializeField] private Toggle _fireToggle;
    [SerializeField] private Toggle _iceToggle;

    private BuildingFactory _currentFactory;
    
    private void Awake()
    {
        _currentFactory = new FireBuildingFactory();
        
        InitButtons();
        InitToggles();
    }

    private void InitButtons()
    {
        _crystalTowerButton.onClick.AddListener((() =>
        {
            if (!_buildingSystem.IsAvailableAnchors())
                return;
            CrystalTower building = _currentFactory.CreateCrystalTower();
            _buildingSystem.StartBuilding(building.gameObject);
        }));
        
        _shardTowerButton.onClick.AddListener((() =>
        {
            if (!_buildingSystem.IsAvailableAnchors())
                return;
            ShardTower building = _currentFactory.CreateShardTower();
            _buildingSystem.StartBuilding(building.gameObject);
        }));
        
        _hexTowerButton.onClick.AddListener((() =>
        {
            if (!_buildingSystem.IsAvailableAnchors())
                return;
            HexTower building = _currentFactory.CreateHexTower();
            _buildingSystem.StartBuilding(building.gameObject);
        }));
    }

    private void InitToggles()
    {
        _fireToggle.onValueChanged.AddListener((val) =>
        {
            if (val)
                _currentFactory = new FireBuildingFactory();
        });
        
        _iceToggle.onValueChanged.AddListener((val) =>
        {
            if (val)
                _currentFactory = new IceBuildingFactory();
        });
    }
}

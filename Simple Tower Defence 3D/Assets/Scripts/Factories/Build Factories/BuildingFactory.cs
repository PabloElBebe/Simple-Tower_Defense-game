using UnityEngine;

public abstract class BuildingFactory
{
    public abstract CrystalTower CreateCrystalTower();
    public abstract ShardTower CreateShardTower();
    public abstract HexTower CreateHexTower();
}

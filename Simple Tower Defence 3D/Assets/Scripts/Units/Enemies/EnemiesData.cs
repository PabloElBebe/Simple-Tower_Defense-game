using System.Collections.Generic;
using UnityEngine;

public static class EnemiesData
{
    private static readonly List<GameObject> _enemies = new List<GameObject>();
    public static IReadOnlyList<GameObject> Enemies => _enemies;

    public static void AddEnemy(GameObject enemy)
    {
        if (_enemies.Contains(enemy))
            return;
        
        _enemies.Add(enemy);
    }

    public static void RemoveEnemy(GameObject enemy)
    {
        if (!_enemies.Contains(enemy))
            return;

        _enemies.Remove(enemy);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemiesPrefabs;
    [SerializeField] private List<Transform> _pathPoints;
    [SerializeField] private Slider _slider;
    private float _time;

    private EnemyFactory _currentFactory;

    private void Awake()
    {
        _currentFactory = new OrcFactory();
        _time = 1;
        _slider.onValueChanged.AddListener((value) =>
        {
            _time = value;
        });
    }

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SpawnEnemy(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Count)]);
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            Enemy enemy = Random.Range(0, 3) switch
            {
                0 => _currentFactory.CreateBasic(_pathPoints),
                1 => _currentFactory.CreateLight(_pathPoints),
                2 => _currentFactory.CreateTank(_pathPoints),
                _ => throw new ArgumentOutOfRangeException()
            };

            Vector3 currentPos = new Vector3(_pathPoints[0].transform.position.x, 1.25f, _pathPoints[0].transform.position.z);
            enemy.transform.position = currentPos;
            EnemiesData.AddEnemy(enemy.gameObject);

            yield return new WaitForSeconds(_time);
        }
    }
    
    private void SpawnEnemy(GameObject enemy)
    {
        Vector3 currentPos = new Vector3(_pathPoints[0].transform.position.x, 1.25f, _pathPoints[0].transform.position.z);
        GameObject spawned = Instantiate(enemy, currentPos, Quaternion.identity);
    }
}

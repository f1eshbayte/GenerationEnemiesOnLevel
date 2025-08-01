using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private EntityMovement _entityPrefab;
    private Transform[] _spawnPoints;
    private float _spawnInterval = 2f;
    private void Start()
    {
        Transform[] allChildren = transform.GetComponentsInChildren<Transform>(false);

        _spawnPoints = new Transform[allChildren.Length - 1];
        for (int i = 1; i < allChildren.Length; i++)
        {
            _spawnPoints[i - 1] = allChildren[i];
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true) // true потому что условия нет никакого, нужно бесконечно
        {
            int randomIndex = Random.Range(0, _spawnPoints.Length);
            Transform spawnPoint = _spawnPoints[randomIndex];

            EntityMovement newEntity = Instantiate(_entityPrefab, spawnPoint.position, spawnPoint.rotation);
            
            var direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;

            newEntity.SetDirection(direction);
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}

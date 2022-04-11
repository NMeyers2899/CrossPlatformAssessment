using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private EnemyMovementBehavior _enemy;

    [SerializeField]
    private Transform _enemyTarget;

    [SerializeField]
    private float _spawnTime = 5.0f;
    private float _timer = 0.0f;

    public EnemyMovementBehavior Enemy
    {
        get { return _enemy; }
        set { _enemy = value; }
    }

    public Transform EnemyTarget
    {
        get { return _enemyTarget; }
        set { _enemyTarget = value; }
    }

    public float SpawnTime
    {
        get { return _spawnTime; }
        set { _spawnTime = value; }
    }

    private void Update()
    {
        if (_timer >= SpawnTime)
        {
            EnemyMovementBehavior spawnedEnemy = Instantiate(_enemy, transform.position, transform.rotation);
            spawnedEnemy.Target = _enemyTarget;
            _timer = 0.0f;
        }

        _timer += Time.deltaTime;
    }
}

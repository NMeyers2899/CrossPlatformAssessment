using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private EnemyMovementBehavior _enemy, _regularEnemy, _fastEnemy, _slowEnemy;

    [SerializeField]
    private Transform _enemyTarget;

    /// <summary>
    /// How much the enemy's health will scale each time they spawn.
    /// </summary>
    private float _healthMultiplier = 1f;

    /// <summary>
    /// The default time it takes an enemy to spawn.
    /// </summary>
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
        if (_timer >= SpawnTime && EnemyTarget)
        {
            // Resets the base spawn time and then makes it longer or shorter at random.
            _spawnTime = 5.0f;
            float respawnTime = Random.Range(-1, 11);
            _spawnTime += respawnTime;

            float enemyChance = Random.Range(1, 101);
            if (enemyChance >= 1 && enemyChance <= 50)
                _enemy = _regularEnemy;
            else if (enemyChance >= 51 && enemyChance <= 80)
                _enemy = _fastEnemy;
            else if (enemyChance >= 81 && enemyChance <= 100)
                _enemy = _slowEnemy;

            EnemyMovementBehavior spawnedEnemy = Instantiate(_enemy, transform.position, transform.rotation);
            spawnedEnemy.Target = _enemyTarget;
            _timer = 0.0f;

            // Finds the health behavior attached to the enemy.
            HealthBehavior enemyHealth = spawnedEnemy.GetComponent<HealthBehavior>();
            if (enemyHealth)
            {
                // Increases the health of the enemy by a small amount and increases the amount that the health multiplier will increase.
                enemyHealth.MultiplyHealth(_healthMultiplier);
                _healthMultiplier *= 1.05f;
            }
                
        }

        _timer += Time.deltaTime;
    }
}

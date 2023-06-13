using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [Tooltip("The different types of enemies this spawner can make.")]
    [SerializeField]
    private EnemyMovementBehavior _enemy, _regularEnemy, _fastEnemy, _slowEnemy;

    [Tooltip("The target the enemies will move towards.")]
    [SerializeField]
    private Transform _enemyTarget;

    [Tooltip("How much the enemy's health will scale each time they spawn.")]
    private float _healthMultiplier = 1f;

    [Tooltip("The default time it takes an enemy to spawn.")]
    [SerializeField]
    private float _spawnTime = 5.0f;
    private float _timer = 0.0f;

    private void Update()
    {
        // If the timer has counted past the alloted spawn time...
        if (_timer >= _spawnTime && _enemyTarget)
        {
            // ...resets the base spawn time and then makes it longer or shorter at random.
            _spawnTime = 5.0f;
            float respawnTime = Random.Range(-1, 11);
            _spawnTime += respawnTime;

            // Finds a random number between 1 and 100 and changes which enemy will spawn based on that number.
            float enemyChance = Random.Range(1, 101);
            if (enemyChance >= 1 && enemyChance <= 50)
                _enemy = _regularEnemy;
            else if (enemyChance >= 51 && enemyChance <= 80)
                _enemy = _fastEnemy;
            else if (enemyChance >= 81 && enemyChance <= 100)
                _enemy = _slowEnemy;

            // Spawns an enemy and resets the timer.
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

        // Increase the timer.
        _timer += Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private MoneyBehavior _playerMoney;

    [SerializeField]
    private HealthBehavior _playerHealth;

    [SerializeField]
    private ProjectileSpawnerBehavior _playerGun;

    [SerializeField]
    private UpgradeButtonTextBehavior _attackUpgradeButton;

    [SerializeField]
    private UpgradeButtonTextBehavior _healthUpgradeButton;

    [SerializeField]
    private static int _enemiesDefeated;

    public static int EnemiesDefeated { get { return _enemiesDefeated; } }

    public void UpgradePlayerDamage()
    {
        if (_playerMoney.MoneyAmount >= _attackUpgradeButton.Cost)
        {
            _playerMoney.DecreaseMoney(_attackUpgradeButton.Cost);
            _playerGun.DamageMultiplier += 0.35f;
            _attackUpgradeButton.Cost *= 1.25f;
        }
    }

    public void UpgradePlayerHealth()
    {
        if(_playerMoney.MoneyAmount >= _healthUpgradeButton.Cost)
        {
            _playerMoney.DecreaseMoney(_healthUpgradeButton.Cost);
            _playerHealth.IncreaseHealth(1);
            _healthUpgradeButton.Cost *= 1.45f;
        }
    }

    public static void IncreaseEnemiesDefeated()
    {
        _enemiesDefeated++;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        _enemiesDefeated = 0;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}

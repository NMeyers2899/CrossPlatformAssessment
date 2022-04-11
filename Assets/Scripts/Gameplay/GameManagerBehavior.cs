using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void UpgradePlayerDamage()
    {
        if (_playerMoney.MoneyAmount >= _attackUpgradeButton.Cost)
        {
            _playerMoney.DecreaseMoney(_attackUpgradeButton.Cost);
            _playerGun.DamageMultiplier *= 1.25f;
        }
    }

    public void UpgradePlayerHealth()
    {
        if(_playerMoney.MoneyAmount >= _healthUpgradeButton.Cost)
        {
            _playerMoney.DecreaseMoney(_healthUpgradeButton.Cost);
            _playerHealth.IncreaseHealth(1);
        }
    }
}

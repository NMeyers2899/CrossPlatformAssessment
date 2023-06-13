using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    [Tooltip("The money behavior attached to the player.")]
    [SerializeField]
    private MoneyBehavior _playerMoney;

    [Tooltip("The health behavior attached to the player.")]
    [SerializeField]
    private HealthBehavior _playerHealth;

    [Tooltip("The projectile spawner attached to the player.")]
    [SerializeField]
    private ProjectileSpawnerBehavior _playerGun;

    [Tooltip("The attack upgrade button.")]
    [SerializeField]
    private UpgradeButtonTextBehavior _attackUpgradeButton;

    [Tooltip("The health upgrade button.")]
    [SerializeField]
    private UpgradeButtonTextBehavior _healthUpgradeButton;

    [Tooltip("The number of enemies defeated by the player.")]
    private static int _enemiesDefeated;

    [Tooltip("The main camera in the scene.")]
    private Camera _camera;

    /// <summary>
    /// The number of enemies defeated by the player.
    /// </summary>
    public static int EnemiesDefeated { get { return _enemiesDefeated; } }

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        // If the aspect ratio is less than 16:9, move the camera upwards. Otherwise, keep it lower.
        if (_camera.aspect < 1.7f)
            _camera.transform.SetPositionAndRotation(new Vector3(0, 15, 3.5f), _camera.transform.rotation);
        else
            _camera.transform.SetPositionAndRotation(new Vector3(0, 10, 3.5f), _camera.transform.rotation);
    }

    /// <summary>
    /// Checks to see if the player has enough money, if they do subtract the cost from their total money and increase their attack power.
    /// </summary>
    public void UpgradePlayerDamage()
    {
        // If the player's money amount is greater than the attack upgrade cost...
        if (_playerMoney.MoneyAmount >= _attackUpgradeButton.Cost)
        {
            // ...decrease their money by the cost, increase their attack and increase the cost of the upgrade.
            _playerMoney.DecreaseMoney(_attackUpgradeButton.Cost);
            _playerGun.DamageMultiplier += 0.35f;
            _attackUpgradeButton.Cost *= 1.25f;
        }
    }

    /// <summary>
    /// Checks to see if the player has enough money, if they do subtract the cost from their total money and increase their total health.
    /// </summary>
    public void UpgradePlayerHealth()
    {
        // If the player's money amount is greater than the health upgrade cost...
        if(_playerMoney.MoneyAmount >= _healthUpgradeButton.Cost)
        {
            // ...decrease their money by the cost, increase their health and increase the cost of the upgrade.
            _playerMoney.DecreaseMoney(_healthUpgradeButton.Cost);
            _playerHealth.IncreaseHealth(1);
            _healthUpgradeButton.Cost *= 1.45f;
        }
    }

    /// <summary>
    /// Increments the amount of enemies defeated.
    /// </summary>
    public static void IncreaseEnemiesDefeated()
    {
        _enemiesDefeated++;
    }

    /// <summary>
    /// Loads the main game scene.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        _enemiesDefeated = 0;
    }

    /// <summary>
    /// Loads the main menu scene.
    /// </summary>
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}

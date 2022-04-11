using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextBehavior : MonoBehaviour
{
    [SerializeField]
    private Text _healthText;

    [SerializeField]
    private HealthBehavior _player;

    // Update is called once per frame
    void Update()
    {
        float health = _player.Health;

        if (health <= 0)
            health = 0;

        _healthText.text = "Health : " + health;
    }
}

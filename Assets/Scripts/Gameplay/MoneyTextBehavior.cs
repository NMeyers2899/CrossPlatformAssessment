using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextBehavior : MonoBehaviour
{
    [Tooltip("The text that will be modified.")]
    [SerializeField]
    private Text _moneyText;

    [Tooltip("The player's money behavior.")]
    [SerializeField]
    private MoneyBehavior _player;

    // Update is called once per frame
    void Update()
    {
        // Checks to see how much money the player has.
        float money = _player.MoneyAmount;

        if (money == 0)
            money = 0;

        // Show the player how much money they have.
        _moneyText.text = "Money : " + money;
    }
}

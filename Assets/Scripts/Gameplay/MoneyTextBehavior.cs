using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextBehavior : MonoBehaviour
{
    [SerializeField]
    private Text _moneyText;

    [SerializeField]
    private MoneyBehavior _player;

    // Update is called once per frame
    void Update()
    {
        float money = _player.MoneyAmount;

        if (money <= 0)
            money = 0;

        _moneyText.text = "Money : " + money;
    }
}

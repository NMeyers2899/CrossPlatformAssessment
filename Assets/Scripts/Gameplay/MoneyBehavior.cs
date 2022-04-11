using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBehavior : MonoBehaviour
{
    [SerializeField]
    private float _moneyAmount;

    public float MoneyAmount
    {
        get { return _moneyAmount; }
    }

    public void AddMoney(float amount)
    {
        _moneyAmount += amount;
        _moneyAmount = (Mathf.Round(_moneyAmount * 100)) / 100;
    }

    public void DecreaseMoney(float amount)
    {
        _moneyAmount -= amount;
        _moneyAmount = (Mathf.Round(_moneyAmount * 100)) / 100;
    }
}

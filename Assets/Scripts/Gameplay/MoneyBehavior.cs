using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBehavior : MonoBehaviour
{
    [Tooltip("How much money this actor currently has.")]
    [SerializeField]
    private float _moneyAmount;

    /// <summary>
    /// How much money this actor currently has.
    /// </summary>
    public float MoneyAmount { get { return _moneyAmount; } }

    /// <summary>
    /// Adds money to the actor's money total.
    /// </summary>
    /// <param name="amount"> The amount being added to the total. </param>
    public void AddMoney(float amount)
    {
        _moneyAmount += amount;
        // Rounds the total to two decimal places.
        _moneyAmount = (Mathf.Round(_moneyAmount * 100)) / 100;
    }

    /// <summary>
    /// Subtracts money from the actor's money total.
    /// </summary>
    /// <param name="amount"> The amount being taken from the total. </param>
    public void DecreaseMoney(float amount)
    {
        _moneyAmount -= amount;
        // Rounds the total to two decimal places.
        _moneyAmount = (Mathf.Round(_moneyAmount * 100)) / 100;
    }
}

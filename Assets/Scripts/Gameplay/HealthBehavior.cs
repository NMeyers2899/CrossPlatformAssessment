using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    [SerializeField]
    private float _health;

    [SerializeField]
    private bool _isAlive;

    [SerializeField]
    private bool _destroyOnDeath;

    public float Health
    {
        get { return _health; }
    }

    public bool IsAlive
    {
        get { return _isAlive; }
    }

    /// <summary>
    /// Decreases the health of the actor by a certain amount and returns the amount.
    /// </summary>
    /// <param name="damageAmount"> The amount of damage being taken. </param>
    public virtual float TakeDamage(float damageAmount)
    {
        _health -= damageAmount;

        return damageAmount;
    }

    /// <summary>
    /// Increases the health of the actor by a certain amount and returns the amount.
    /// </summary>
    /// <param name="healAmount"> The amount that health is being increased by. </param>
    public virtual float IncreaseHealth(float healAmount)
    {
        _health += healAmount;

        return healAmount;
    }

    /// <summary>
    /// Multiplies the health of the actor by the amount given and returns that amount.
    /// </summary>
    /// <param name="increaseAmount"> The number that health is being multiplied by. </param>
    public virtual float MultiplyHealth(float increaseAmount)
    {
        _health *= increaseAmount;

        return increaseAmount;
    }

    public virtual void OnDeath()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If the actor has no health and is still alive...
        if (_health <= 0 & IsAlive)
            // ...perform the logic in the OnDeath function.
            OnDeath();

        _isAlive = _health > 0;

        if (!IsAlive && _destroyOnDeath)
            Destroy(gameObject);
    }
}

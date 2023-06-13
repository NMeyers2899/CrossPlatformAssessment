using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MovementBehavior
{
    [Tooltip("The target this enemy will move towards.")]
    [SerializeField]
    private Transform _target;

    [Tooltip("How fast this enemy will move.")]
    [SerializeField]
    private float _enemyMoveSpeed;

    [Tooltip("The amount of money this enemy will drop on death.")]
    [SerializeField]
    private float _dropAmount;

    /// <summary>
    /// The target this enemy will move towards.
    /// </summary>
    public Transform Target { get { return _target; } set { _target = value; } }

    public override void Update()
    {
        // If there is a target...
        if (Target)
        {
            // ...get the distance between the enemy and the target.
            Vector3 direction = Target.position - transform.position;
            Velocity = direction.normalized * _enemyMoveSpeed;
        }
        // If there is not a target, destroy this actor.
        else
            Destroy(gameObject);

        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _target)
        {
            // Finds the health behavior of the target, and then has that target take one damage if that health behavior exists.
            HealthBehavior characterHealth = other.GetComponent<HealthBehavior>();
            if (characterHealth)
                characterHealth.TakeDamage(1);
            // If their health is less than or equal to zero...
            if(characterHealth.Health <= 0)
            {
                // ...call their destroy function.
                PlayerInputBehavior player = other.GetComponent<PlayerInputBehavior>();
                player.Destroy();
            }

            Destroy(gameObject);
        }

        if(other.transform != Target && other.CompareTag("Bullet"))
        {
            // Adds money to the character's total.
            MoneyBehavior characterMoney = Target.GetComponent<MoneyBehavior>();
            if (characterMoney)
                characterMoney.AddMoney(_dropAmount);
        }
    }
}

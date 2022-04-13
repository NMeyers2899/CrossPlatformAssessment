using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MovementBehavior
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _enemyMoveSpeed;

    /// <summary>
    /// The amount of money this enemy will drop on death.
    /// </summary>
    [SerializeField]
    private float _dropAmount;

    public Transform Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public float EnemyMoveSpeed
    {
        get { return _enemyMoveSpeed; }
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Target)
        {
            // Getting the distance between the enemy and the target.
            Vector3 direction = Target.position - transform.position;
            Velocity = direction.normalized * EnemyMoveSpeed;
        }
        else
            Destroy(gameObject);

        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == Target)
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

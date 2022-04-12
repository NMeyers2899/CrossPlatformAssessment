using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MovementBehavior
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _enemyMoveSpeed;

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

        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == Target)
        {
            HealthBehavior characterHealth = other.GetComponent<HealthBehavior>();
            if (characterHealth)
                characterHealth.TakeDamage(1);
            if(characterHealth.Health <= 0)
            {
                PlayerInputBehavior player = other.GetComponent<PlayerInputBehavior>();
                player.Destroy();
            }

            Destroy(gameObject);
        }

        if(other.transform != Target && other.CompareTag("Bullet"))
        {
            MoneyBehavior characterMoney = Target.GetComponent<MoneyBehavior>();
            if (characterMoney)
                characterMoney.AddMoney(_dropAmount);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MovementBehavior
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _enemyMoveSpeed;

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
            PlayerInputBehavior character = other.GetComponent<PlayerInputBehavior>();
            if (character)
                character.();

            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [Tooltip("The tag of the owner.")]
    private string _ownerTag;

    [Tooltip("The rigidbody of the bullet.")]
    private Rigidbody _rigidbody;

    [Tooltip("The amount of time this bullet will stay active.")]
    [SerializeField]
    private float _lifeTime;
    private float _currentLifeTime;

    [Tooltip("Determines whether or not this bullet should destroy itself upon colliding.")]
    [SerializeField]
    private bool _destroyOnHit;

    [Tooltip("How much damage the bullet should do.")]
    [SerializeField]
    private float _damage;

    /// <summary>
    /// The rigidbody of the bullet.
    /// </summary>
    public Rigidbody RigidBody { get { return _rigidbody; } }

    /// <summary>
    /// How much damage the bullet should do.
    /// </summary>
    public float Damage { get { return _damage; } set { _damage = value; } }

    /// <summary>
    /// The tag of the owner.
    /// </summary>
    public string OwnerTag { get { return _ownerTag; } set { _ownerTag = value; } }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the other is the owner, don't do anything.
        if (other.CompareTag(OwnerTag))
            return;

        // If the other is an enemy...
        if (other.tag == "Enemy")
        {
            // ...check to see if they have a health behavior.
            HealthBehavior otherHealth = other.GetComponent<HealthBehavior>();
            // If they do, deal damage to them.
            if (otherHealth)
                otherHealth.TakeDamage(_damage);
            // If their health is less than or equal to zero, increment the Game Manager's enemies defeated counter.
            if (otherHealth.Health <= 0)
                GameManagerBehavior.IncreaseEnemiesDefeated();
        }

        if (_destroyOnHit)
            Destroy(gameObject);
    }

    private void Update()
    {
        // Increase the timer.
        _currentLifeTime += Time.deltaTime;

        // If the timer is over the alloted life time, destroy the bullet.
        if (_currentLifeTime >= _lifeTime)
            Destroy(gameObject);
    }
}

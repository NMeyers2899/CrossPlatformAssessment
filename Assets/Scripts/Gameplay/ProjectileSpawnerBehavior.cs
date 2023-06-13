using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerBehavior : MonoBehaviour
{
    [Tooltip("The projectile that will be fired.")]
    [SerializeField]
    private BulletBehavior _projectileRef;

    [Tooltip("The amount of force that will be applied to the projectile.")]
    [SerializeField]
    private float _projectileForce;

    [Tooltip("The actor that owns this projectile spawner.")]
    [SerializeField]
    private GameObject _owner;

    [Tooltip("The amount that damage will be multiplied by.")]
    private float _damageMultiplier = 1;

    /// <summary>
    /// The amount that damage will be multiplied by.
    /// </summary>
    public float DamageMultiplier { get { return _damageMultiplier; } set { _damageMultiplier = value; } }

    /// <summary>
    /// Instantiate's a projectile and adds a force to it.
    /// </summary>
    public void Fire()
    {
        // Creates a bullet and adds a force to it. Also changes the bullet's damage.
        GameObject bullet = Instantiate(_projectileRef.gameObject, transform.position, transform.rotation);
        BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
        bulletBehavior.Damage *= DamageMultiplier;
        bulletBehavior.OwnerTag = _owner.tag;
        bulletBehavior.RigidBody.AddForce(transform.forward * _projectileForce, ForceMode.Impulse);
    }
}

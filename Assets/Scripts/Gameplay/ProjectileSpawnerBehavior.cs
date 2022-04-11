using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private BulletBehavior _projectileRef;

    [SerializeField]
    private float _projectileForce;

    [SerializeField]
    private GameObject _owner;

    private float _damageMultiplier = 1;

    public float DamageMultiplier
    {
        get { return _damageMultiplier; }
        set { _damageMultiplier = value; }
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(_projectileRef.gameObject, transform.position, transform.rotation);
        BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
        bulletBehavior.Damage *= DamageMultiplier;
        bulletBehavior.OwnerTag = _owner.tag;
        bulletBehavior.RigidBody.AddForce(transform.forward * _projectileForce, ForceMode.Impulse);
    }
}

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

    public void Fire()
    {
        GameObject bullet = Instantiate(_projectileRef.gameObject, transform.position, transform.rotation);
        BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
        bulletBehavior.OwnerTag = _owner.tag;
        bulletBehavior.RigidBody.AddForce(transform.forward * _projectileForce, ForceMode.Impulse);
    }
}

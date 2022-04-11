using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private string _ownerTag;

    private Rigidbody _rigidbody;

    [SerializeField]
    private float _lifeTime;
    private float _currentLifeTime;

    [SerializeField]
    private bool _destroyOnHit;

    [SerializeField]
    private float _damage;

    public Rigidbody RigidBody
    {
        get { return _rigidbody; }
    }

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public string OwnerTag
    {
        get { return _ownerTag; }
        set { _ownerTag = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(OwnerTag))
            return;

        if (_destroyOnHit)
            Destroy(gameObject);

        if (other.tag == "Enemy")
            Destroy(other.gameObject);
    }

    private void Update()
    {
        _currentLifeTime += Time.deltaTime;

        if (_currentLifeTime >= _lifeTime)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [Tooltip("The velocity of the actor.")]
    private Vector3 _velocity;

    /// <summary>
    /// The velocity of the actor.
    /// </summary>
    public Vector3 Velocity { get { return _velocity; } set { _velocity = value; } }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.position += Velocity * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionWithObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CollisionObjects(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionObjects(collision.collider);
    }

    public abstract void CollisionObjects(Collider other);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroiedByTrident : CollisionWithObjects
{
    public override void CollisionObjects(Collider other)
    {
        if (other.CompareTag("Trident"))
        {
            GetComponent<Animator>().SetTrigger("Destroy");
        }
    }

}

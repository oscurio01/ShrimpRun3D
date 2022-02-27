using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDislikeToShrimps : CollisionWithObjects
{
    public override void CollisionObjects(Collider other)
    {
        if (other.CompareTag("Pointer"))
        {
            other.transform.parent.GetComponent<PlayerLevelController>().EraseShrimp(other.gameObject);
        }
    }

}

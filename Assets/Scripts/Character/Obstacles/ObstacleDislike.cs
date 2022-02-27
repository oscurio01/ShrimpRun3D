using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDislike : CollisionWithObjects
{
    public override void CollisionObjects(Collider other)
    {
        if(other.GetComponent<PlayerLevelController>())
        other.GetComponent<PlayerLevelController>().DecreaseShrimp();

    }
}

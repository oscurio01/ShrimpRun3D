using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLava : CollisionWithObjects
{
    public override void CollisionObjects(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerLevelController>().GetTotalShrimps() > 0 || other.GetComponent<PlayerLevelController>().GetForce() > 0)
            {
                other.GetComponent<PlayerLevelController>().DecreaseShrimp();
            }
            else
            {
                GameOverMenu.gameOverIsON = true;
            }
            
        }
    }

}

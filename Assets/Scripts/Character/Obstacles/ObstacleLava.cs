using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLava : CollisionWithObjects
{
    public override void CollisionObjects(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerController>().GetTotalShrimps() % 20 == 1 && other.GetComponent<PlayerController>().GetTotalShrimps() != 1)
            {
                other.GetComponent<PlayerController>().DecreaseShrimp();
                other.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -50 * 100), ForceMode.Force);
            }
            else if(other.GetComponent<PlayerController>().GetForce() > 0)
            {
                other.GetComponent<PlayerController>().DecreaseForce(1);

            }
            else
            {
                GameOverMenu.gameOverIsON = true;
            }
            
        }
    }

}

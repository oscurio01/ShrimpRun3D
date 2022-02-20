using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAlly : CollisionWithObjects
{
    public override void CollisionObjects(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLevelController>().SetListAlly(1);

            Destroy(this.gameObject);
        }
    }
}

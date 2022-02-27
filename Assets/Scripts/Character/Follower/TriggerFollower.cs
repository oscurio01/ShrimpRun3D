using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFollower : CollisionWithObjects
{
    public override void CollisionObjects(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerLevelController>()) {

            other.gameObject.GetComponent<PlayerLevelController>().AddFollower();

            AudioManager.instance.PlayAudioSelected("EffectGetShrimp");

            Destroy(this.gameObject);
        }
       
    }
}

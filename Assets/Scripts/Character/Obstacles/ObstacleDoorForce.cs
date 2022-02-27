using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleDoorForce : CollisionWithObjects
{
    [SerializeField] int forceNedded;
    [SerializeField] TMP_Text text;
    PlayerLevelController player;

    private void Awake()
    {
        text.text = "" + forceNedded;
    }
    public override void CollisionObjects(Collider other)
    {
        player = other.GetComponent<PlayerLevelController>();
        if (player)
        {
            if(forceNedded <= player.GetForce())
            {
                Destroy(gameObject);
            }
            else
            {
                GameOverMenu.gameOverIsON = true;
            }
        }
    }

}

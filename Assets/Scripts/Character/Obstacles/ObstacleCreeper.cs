using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreeper : CollisionWithObjects
{

    private float maxDistance = 23;
    [SerializeField] private float distance;
    private float timer;

    bool onlyOnce = false;

    GameObject player;


    public override void CollisionObjects(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < 19; i++)
            {
                if (other.GetComponent<PlayerLevelController>().GetTotalShrimps() > 0 || other.GetComponent<PlayerLevelController>().GetForce() > 0)
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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(transform.position.x, 0, transform.position.z));

        if(distance < maxDistance && !onlyOnce)
        {
            GetComponentInChildren<Animator>().SetTrigger("Explote");

            onlyOnce = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}

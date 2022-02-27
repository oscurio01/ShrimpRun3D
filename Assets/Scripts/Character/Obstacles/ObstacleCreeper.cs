using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreeper : MonoBehaviour
{

    [SerializeField] private float maxDistance = 22;
    [SerializeField] private float distance;

    [SerializeField] private GameObject ratioOfExplosion;

    private float timer;

    bool onlyOnce = false;

    GameObject player;

    PlayerLevelController playerFollowers;

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
            ratioOfExplosion.SetActive(true);
            onlyOnce = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}

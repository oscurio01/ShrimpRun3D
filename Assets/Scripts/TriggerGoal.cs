using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : CollisionWithObjects
{
    public static bool StageComplete = false;

    public GameObject WinPanel;

    [SerializeField] private float timer = 20;

    bool onlyOnce = false;

    private void Awake()
    {
        WinPanel.SetActive(false);
        onlyOnce = false;
    }

    private void Update()
    {
        if (StageComplete && onlyOnce == false)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0 && onlyOnce == false)
        {
            WinPanel.SetActive(true);
            onlyOnce = true;
        }
    }

    public override void CollisionObjects(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StageComplete = true;
            other.GetComponent<Animator>().SetTrigger("Celebrate");

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFollowers : MonoBehaviour
{
    public static event Action<int, int> SendFollowers = delegate { };

    void OnEnable()
    {
        GetComponent<PlayerLevelController>().CallFollower += GetFollowers;
    }

    void OnDisable()
    {
        GetComponent<PlayerLevelController>().CallFollower -= GetFollowers;
    }

    void GetFollowers(int follower, int maxFollowers)
    {
        SendFollowers(follower, maxFollowers);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForce : MonoBehaviour
{
    public static event Action<int> SendForce = delegate { };

    void OnEnable()
    {
        GetComponent<PlayerLevelController>().CallForce += GetForce;
    }

    void OnDisable()
    {
        GetComponent<PlayerLevelController>().CallForce -= GetForce;
    }

    void GetForce(int force)
    {
        SendForce(force);
    }
}

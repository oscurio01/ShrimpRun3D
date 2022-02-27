using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalForcePlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Text textForce;

    void OnEnable()
    {
        CheckForce.SendForce += TextForce;
    }

    void OnDisable()
    {
        CheckForce.SendForce -= TextForce;
    }

    public void TextForce(int force)
    {
        textForce.text = "" + force;
    }
}

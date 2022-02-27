using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalShrimpsPlayer : MonoBehaviour
{
    public static event Action renameScore = delegate { };

    [SerializeField] private GameObject player;
    [SerializeField] private Slider sliderShrimp;
    [SerializeField] private Text textShrimp;

    void OnEnable()
    {
        CheckFollowers.SendFollowers += TextShrimp;
    }

    void OnDisable()
    {
        CheckFollowers.SendFollowers -= TextShrimp;
    }

    public void TextShrimp(int followers, int maxFollowers)
    {
        textShrimp.text = "" + followers + "/" + maxFollowers;

        sliderShrimp.minValue = 0;
        sliderShrimp.maxValue = maxFollowers;

        sliderShrimp.value = followers;

        renameScore();
    }
}

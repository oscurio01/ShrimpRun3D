using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountShrimpsFromPlayer : MonoBehaviour
{
    [SerializeField] private Slider countOfShrimps;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    void SlideValue(int value)
    {
        countOfShrimps.value = value;
    }
}

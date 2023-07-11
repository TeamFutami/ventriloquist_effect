using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTask : MonoBehaviour
{
    [SerializeField] private GameObject arrowUp;
    [SerializeField] private GameObject arrowDown;
    [SerializeField] private GameObject arrowLeft;
    [SerializeField] private GameObject arrowRight;
    
    public void ShowArrow()
    {
        var random = new System.Random();
        var num = random.Next(1, 5);
        switch (num)
        {
            case 1:
                arrowUp.SetActive(true);
                break;
            case 2:
                arrowDown.SetActive(true);
                break;
            case 3:
                arrowLeft.SetActive(true);
                break;
            case 4:
                arrowRight.SetActive(true);
                break;
        }
    }
    
    public void HideArrow()
    {
        arrowUp.SetActive(false);
        arrowDown.SetActive(false);
        arrowLeft.SetActive(false);
        arrowRight.SetActive(false);
    }
}
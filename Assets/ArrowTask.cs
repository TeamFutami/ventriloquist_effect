using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTask : MonoBehaviour
{
    // 矢印の向きを回答する関数
    public async void AnswerArrow(Vector2 value)
    {
        var x = value.x;
        var y = value.y;
        
        if (y >= Math.Sqrt(2))
        {
            Debug.Log("上");
        }
        else if (y <= -Math.Sqrt(2))
        {
            Debug.Log("下");
        }
        else if(x >= Math.Sqrt(2))
        {
            Debug.Log("右");
        }
        else if(x <= -Math.Sqrt(2))
        {
            Debug.Log("左");
        }
    }
}
using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class PrimaryReactor : MonoBehaviour
{
    public PrimaryAxisWatcher primaryAxisWatcher;
    private Coroutine _coroutine;
    [SerializeField] private TextMeshProUGUI textMeshProUgui;
    
    private void Start()
    {
        primaryAxisWatcher.primary2DAxisEvent.AddListener(OnPrimary2DAxisEvent);
    }
    
    public void OnPrimary2DAxisEvent(Vector2 value)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(OnPrimary2DAxisEventCoroutine(value));
    }
    
    private IEnumerator OnPrimary2DAxisEventCoroutine(Vector2 value)
    {
        var x = value.x;
        var y = value.y;

        if (x==0 && y==0)
        {
            yield return new WaitForSeconds(10f);
            textMeshProUgui.text = "center";
        }
        else if (y >= Math.Sqrt(2) / 2)
        {
            Debug.Log("上");
            textMeshProUgui.text = "up";
        }
        else if (y <= -Math.Sqrt(2) / 2)
        {
            Debug.Log("下");
            textMeshProUgui.text = "down";
        }
        else if(x >= Math.Sqrt(2) / 2)
        {
            Debug.Log("右");
            textMeshProUgui.text = "right";
        }
        else if(x <= -Math.Sqrt(2) / 2)
        {
            Debug.Log("左");
            textMeshProUgui.text = "left";
        }
        else
        {
            textMeshProUgui.text = "";
        }

        yield return null;
    }
}

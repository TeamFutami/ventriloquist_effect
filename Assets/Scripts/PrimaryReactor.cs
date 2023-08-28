using System.Collections;
using UnityEngine;
using TMPro;
using System;
using System.Globalization;

public class PrimaryReactor : MonoBehaviour
{
    public PrimaryAxisWatcher primaryAxisWatcher;
    private Coroutine _coroutine;
    [SerializeField] private TextMeshProUGUI textMeshProUgui;
    [SerializeField] private TextMeshProUGUI timerTextMeshProUgui;
    [SerializeField] private ArrowTask arrowTask;
    [SerializeField] private float waitTime = 3f;
    [SerializeField] private TimerLogger timerLogger;
    [SerializeField] private SaveCsv saveCsv;
    public float timer;
    private bool _count;
    private string _correctArrow;
    private string _selectArrow;

    private void Start()
    {
        primaryAxisWatcher.primary2DAxisEvent.AddListener(OnPrimary2DAxisEvent);
        // arrowTask.ShowArrow();
        timer = 0f;
    }
    
    private void Update()
    {
        if (!_count) return;
        timer += Time.deltaTime;
        timerTextMeshProUgui.text = timer.ToString();
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
        
        if (x == 0 && y == 0)
        {
            yield return new WaitForSeconds(waitTime);
            textMeshProUgui.text = "center";
            _correctArrow = arrowTask.ShowArrow();
            _count = true;
            yield break;
        }
        
        if (y >= Math.Sqrt(2) / 2)
        {
            Debug.Log("上");
            textMeshProUgui.text = "up";
            _selectArrow = "up";
        }
        else if (y <= -Math.Sqrt(2) / 2)
        {
            Debug.Log("下");
            textMeshProUgui.text = "down";
            _selectArrow = "down";
        }
        else if(x >= Math.Sqrt(2) / 2)
        {
            Debug.Log("右");
            textMeshProUgui.text = "right";
            _selectArrow = "right";
        }
        else if(x <= -Math.Sqrt(2) / 2)
        {
            Debug.Log("左");
            textMeshProUgui.text = "left";
            _selectArrow = "left";
        }
        
        arrowTask.HideArrow();
        _count = false;
        if (timer != 0)
        {
            timerLogger.LogTimer(timer);
            timerLogger.LogArrow(_selectArrow, _correctArrow);
            saveCsv.SaveData(_selectArrow, _correctArrow, timer.ToString(CultureInfo.InvariantCulture));
        }
        timer = 0f;

        yield return null;
    }
}

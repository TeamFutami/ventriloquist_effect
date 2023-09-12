using System.Collections;
using UnityEngine;
//using TMPro;

public class PrimaryButtonReactor : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    private Coroutine _counter;
    public int count;
    // text
    //[SerializeField] private TextMeshProUGUI textMeshProUgui;

    void Start()
    {
        watcher.primaryButtonPress.AddListener(OnPrimaryButtonEvent);
    }

    public void OnPrimaryButtonEvent(bool pressed)
    {
        if (_counter != null)
            StopCoroutine(_counter);
        if (pressed)
            _counter = StartCoroutine(Counter());
    }

    private IEnumerator Counter()
    {
        yield return null;
        count++;
        //textMeshProUgui.text = count.ToString();
    }
}

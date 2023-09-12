using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PrimaryButtonReactor : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    private Coroutine _counter;
    public int count;

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
        count++;
        yield return null;
    }
}

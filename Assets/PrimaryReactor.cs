using System.Collections;
using UnityEngine;
using TMPro;

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
        textMeshProUgui.text = value.ToString();
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(OnPrimary2DAxisEventCoroutine(value));
    }
    
    private IEnumerator OnPrimary2DAxisEventCoroutine(Vector2 value)
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("OnPrimary2DAxisEventCoroutine");
        _coroutine = null;
    }
}

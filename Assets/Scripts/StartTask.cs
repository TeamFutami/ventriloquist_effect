using UnityEngine;

public class StartTask : MonoBehaviour
{
    [SerializeField] private VideoManager videoManager;
    [SerializeField] private ArrowTask arrowTask;
    [SerializeField] private SaveCsv saveCsv;

    public void StartTaskMethod(bool isFirst)
    {
        videoManager.PlayVideo(isFirst);
        arrowTask.ShowArrowCall();
    }
    
    public void StopTaskMethod()
    {
        videoManager.ResetVideo();
        arrowTask.HideArrowCall();
        saveCsv.SaveCount();
        Debug.Log("StopTaskMethod");
        saveCsv.EndTask();
    }
}
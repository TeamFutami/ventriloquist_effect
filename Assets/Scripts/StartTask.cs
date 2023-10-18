using UnityEngine;
using Photon.Pun;

public class StartTask : MonoBehaviour
{
    [SerializeField] private VideoManager videoManager;
    [SerializeField] private ArrowTask arrowTask;
    [SerializeField] private SaveCsv saveCsv;

    public void StartTaskMethod()
    {
        videoManager.PlayVideo();
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
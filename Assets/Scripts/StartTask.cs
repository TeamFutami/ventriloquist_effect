using UnityEngine;
using Photon.Pun;

public class StartTask : MonoBehaviourPunCallbacks
{
    [SerializeField] private VideoManager videoManager;
    [SerializeField] private ArrowTask arrowTask;
    [SerializeField] private SaveCsv saveCsv;
    [SerializeField] private PrimaryButtonReactor primaryButtonReactor;

    public void StartTaskMethod()
    {
        videoManager.PlayVideo();
        arrowTask.ShowArrowCall();
    }
    
    public void StopTaskMethod()
    {
        videoManager.ResetVideo();
        arrowTask.HideArrowCall();
        Debug.Log("StopTaskMethod");
        saveCsv.SaveCount(primaryButtonReactor.count.ToString());
        saveCsv.EndTask();
    }
}
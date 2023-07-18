using UnityEngine;
using Photon.Pun;

public class StartTask : MonoBehaviourPunCallbacks
{
    [SerializeField] private VideoManager videoManager;
    [SerializeField] private ArrowTask arrowTask;
    
    public void StartTaskMethod()
    {
        videoManager.PlayVideo();
        arrowTask.ShowArrowCall();
    }
}
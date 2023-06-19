using UnityEngine;
using Photon.Pun;
using UnityEngine.Video;

public class VideoManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private VideoPlayer videoPlayer;
    
    public void PlayVideo()
    {
        photonView.RPC("RPCPlayVideo", RpcTarget.Others);
    }

    public void ResetVideo()
    {
        photonView.RPC("RPCResetVideo", RpcTarget.Others);
    }

    [PunRPC]
    private void RPCPlayVideo()
    {
        videoPlayer.Play();
    }
    
    [PunRPC]
    private void RPCResetVideo()
    {
        videoPlayer.Stop();
    }
}

using UnityEngine;
using Photon.Pun;
using UnityEngine.Video;

public class VideoManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private VideoPlayer nVideoPlayer;
    [SerializeField] private VideoPlayer sVideoPlayer;
    
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
        nVideoPlayer.Play();
        sVideoPlayer.Play();
    }
    
    [PunRPC]
    private void RPCResetVideo()
    {
        nVideoPlayer.Stop();
        sVideoPlayer.Stop();
    }
}

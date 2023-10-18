using UnityEngine;
using Photon.Pun;
using UnityEngine.Video;

public class VideoManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private VideoPlayer nVideoPlayer;
    [SerializeField] private VideoPlayer sVideoPlayer;
    [SerializeField] private VideoPlayer nVideoPlayer2;
    [SerializeField] private VideoPlayer sVideoPlayer2;

    public void PlayVideo(bool isFirst)
    {
        photonView.RPC(isFirst ? nameof(RPCPlayVideo) : nameof(RPCPlayVideo2), RpcTarget.Others);
    }

    public void ResetVideo()
    {
        photonView.RPC(nameof(RPCResetVideo), RpcTarget.Others);
    }

    [PunRPC]
    private void RPCPlayVideo()
    {
        nVideoPlayer.Play();
        sVideoPlayer.Play();
    }

    [PunRPC]
    private void RPCPlayVideo2()
    {
        nVideoPlayer2.Play();
        sVideoPlayer2.Play();
    }

    [PunRPC]
    private void RPCResetVideo()
    {
        nVideoPlayer.Stop();
        sVideoPlayer.Stop();
        nVideoPlayer2.Stop();
        sVideoPlayer2.Stop();
    }
}
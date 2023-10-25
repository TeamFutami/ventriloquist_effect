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
        nVideoPlayer.gameObject.SetActive(true);
        sVideoPlayer.gameObject.SetActive(true);
        nVideoPlayer.Play();
        sVideoPlayer.Play();
    }

    [PunRPC]
    private void RPCPlayVideo2()
    {
        nVideoPlayer2.gameObject.SetActive(true);
        sVideoPlayer2.gameObject.SetActive(true);
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
        nVideoPlayer.gameObject.SetActive(false);
        sVideoPlayer.gameObject.SetActive(false);
        nVideoPlayer2.gameObject.SetActive(false);
        sVideoPlayer2.gameObject.SetActive(false);
    }
}
using UnityEngine;
using Photon.Pun;

public class ReceiveState : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private GameObject nVideo;
    [SerializeField] private GameObject sVideo;
    [SerializeField] private GameObject nVideo2;
    [SerializeField] private GameObject sVideo2;

    [SerializeField] private GameObject nMask;
    [SerializeField] private GameObject sMask;

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) return;
        nVideo.SetActive((bool)stream.ReceiveNext());
        sVideo.SetActive((bool)stream.ReceiveNext());
        nVideo2.SetActive((bool)stream.ReceiveNext());
        sVideo2.SetActive((bool)stream.ReceiveNext());
        nMask.SetActive((bool)stream.ReceiveNext());
        sMask.SetActive((bool)stream.ReceiveNext());
    }
}
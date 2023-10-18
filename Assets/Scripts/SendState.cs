using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SendState : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private Toggle nVideo;
    [SerializeField] private Toggle sVideo;

    [SerializeField] private Toggle nVideo2;
    [SerializeField] private Toggle sVideo2;

    [SerializeField] private Toggle nMask;
    [SerializeField] private Toggle sMask;

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (!stream.IsWriting) return;
        stream.SendNext(nVideo.isOn);
        stream.SendNext(sVideo.isOn);
        stream.SendNext(nVideo2.isOn);
        stream.SendNext(sVideo2.isOn);
        stream.SendNext(nMask.isOn);
        stream.SendNext(sMask.isOn);
    }
}
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SendState : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private Toggle nMask;
    [SerializeField] private Toggle sMask;

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (!stream.IsWriting) return;
        stream.SendNext(nMask.isOn);
        stream.SendNext(sMask.isOn);
    }
}
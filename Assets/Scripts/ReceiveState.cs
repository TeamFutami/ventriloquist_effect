using UnityEngine;
using Photon.Pun;

public class ReceiveState : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private GameObject nMask;
    [SerializeField] private GameObject sMask;

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) return;
        nMask.SetActive((bool)stream.ReceiveNext());
        sMask.SetActive((bool)stream.ReceiveNext());
    }
}
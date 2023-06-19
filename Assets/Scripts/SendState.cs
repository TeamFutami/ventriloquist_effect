using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SendState : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private Toggle toggle;
    
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            stream.SendNext(toggle.isOn);
        }
    }
}

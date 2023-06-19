using UnityEngine;
using Photon.Pun;

public class ReceiveState : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private GameObject cube;
    
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (!stream.IsWriting) {
            cube.SetActive((bool)stream.ReceiveNext());
        }
    }
}

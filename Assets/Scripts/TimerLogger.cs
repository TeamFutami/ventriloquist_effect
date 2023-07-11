using UnityEngine;
using Photon.Pun;

public class TimerLogger : MonoBehaviourPunCallbacks
{
    public void LogTimer(float timer)
    {
        photonView.RPC(nameof(RPCLogTimer), RpcTarget.Others, timer);
    }
    
    [PunRPC]
    private void RPCLogTimer(float timer)
    {
        Debug.Log(timer);
    }
}

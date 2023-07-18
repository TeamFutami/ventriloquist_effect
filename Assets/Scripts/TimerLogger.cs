using Photon.Pun;
using UnityEngine;

public class TimerLogger : MonoBehaviourPunCallbacks
{
    public void LogTimer(float timer)
    {
        photonView.RPC(nameof(RPCLogTimer), RpcTarget.Others, timer);
    }
    
    public void LogArrow(string selectArrow, string correctArrow)
    {
        photonView.RPC(nameof(RPCLogArrow), RpcTarget.Others, selectArrow, correctArrow);
    }

    [PunRPC]
    private void RPCLogTimer(float timer)
    {
        Debug.Log(timer);
    }
    
    [PunRPC]
    private void RPCLogArrow(string selectArrow, string correctArrow)
    {
        Debug.Log($"selectArrow: {selectArrow}, correctArrow: {correctArrow}");
        Debug.Log("--------------------");
    }
}

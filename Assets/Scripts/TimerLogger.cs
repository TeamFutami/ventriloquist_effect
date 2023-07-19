using Photon.Pun;
using UnityEngine;

public class TimerLogger : MonoBehaviourPunCallbacks
{
    public void LogTimer(float timer)
    {
        photonView.RPC(nameof(RPCLogTimer), RpcTarget.Others, timer);
    }
    
    public void LogArrow(string selectArrow, string symbolArrow, string charArrow)
    {
        photonView.RPC(nameof(RPCLogArrow), RpcTarget.Others, selectArrow, symbolArrow, charArrow);
    }

    [PunRPC]
    private void RPCLogTimer(float timer)
    {
        Debug.Log(timer);
    }
    
    [PunRPC]
    private void RPCLogArrow(string selectArrow, string symbolArrow, string charArrow)
    {
        Debug.Log($"selectArrow: {selectArrow}, symbolArrow: {symbolArrow}, charArrow: {charArrow}");
        Debug.Log("--------------------");
    }
}

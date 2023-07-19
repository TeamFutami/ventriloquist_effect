using Photon.Pun;
using UnityEngine;

public class TimerLogger : MonoBehaviourPunCallbacks
{
    public void LogTimer(float timer)
    {
        photonView.RPC(nameof(RPCLogTimer), RpcTarget.Others, timer);
    }
    
    public void LogArrow(string question, string selectArrow, string symbolArrow, string charArrow)
    {
        photonView.RPC(nameof(RPCLogArrow), RpcTarget.Others, question, selectArrow, symbolArrow, charArrow);
    }

    [PunRPC]
    private void RPCLogTimer(float timer)
    {
        Debug.Log(timer);
    }
    
    [PunRPC]
    private void RPCLogArrow(string question, string selectArrow, string symbolArrow, string charArrow)
    {
        Debug.Log($"question: {question}, selectArrow: {selectArrow}, symbolArrow: {symbolArrow}, charArrow: {charArrow}");
        Debug.Log("--------------------");
    }
}

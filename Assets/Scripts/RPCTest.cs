using UnityEngine;
using Photon.Pun;
using TMPro;

public class RPCTest : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI textMeshProUgui;
    public void OnButtonClicked()
    {
        photonView.RPC("RPCMethod", RpcTarget.All);
    }
    
    [PunRPC]
    private void RPCMethod()
    {
        if(!photonView.IsMine)
        {
            textMeshProUgui.text = "RPCMethod";
        }
    }
}

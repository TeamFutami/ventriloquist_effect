using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Join : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーに接続した時に呼ばれる
    public override void OnConnectedToMaster()
    {
        Debug.Log("マスターサーバーに接続しました");
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }
    
    // ルームに入室した時に呼ばれる
    public override void OnJoinedRoom()
    {
        Debug.Log("ルームに入室しました");
        PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity);
    }
}

using System.IO;
using System.Text;
using UnityEngine;
using System;
using Photon.Pun;

public class SaveCsv : MonoBehaviourPunCallbacks
{
    private StreamWriter _streamWriter;
    
    private void Start()
    {
        var fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
        var path = Path.Combine(Application.streamingAssetsPath, "log", $"{fileName}.csv");
        _streamWriter = new StreamWriter(path, true, Encoding.GetEncoding("Shift_JIS"));
        string[] s1 = { "select arrow", "correct arrow", "time" };
        var s2 = string.Join(",", s1);
        _streamWriter.WriteLine(s2);
        Debug.Log("Write Title");
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _streamWriter.Close();
            Debug.Log("Close");
        }
    }

    public void SaveData(string txt1, string txt2, string txt3)
    {
        photonView.RPC(nameof(RpcSaveData), RpcTarget.Others, txt1, txt2, txt3);
    }
    
    [PunRPC]
    private void RpcSaveData(string txt1, string txt2, string txt3)
    {
        string[] s1 = { txt1, txt2, txt3 };
        var s2 = string.Join(",", s1);
        _streamWriter.WriteLine(s2);
    }
}

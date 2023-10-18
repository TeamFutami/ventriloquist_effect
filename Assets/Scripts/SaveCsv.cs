using System.IO;
using System.Text;
using UnityEngine;
using System;
using Photon.Pun;

public class SaveCsv : MonoBehaviourPunCallbacks
{
    private StreamWriter _streamWriter;
    [SerializeField] private PrimaryButtonReactor primaryButtonReactor;
    
    private void Start()
    {
        var fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
        var path = Path.Combine(Application.streamingAssetsPath, "log", $"{fileName}.csv");
        _streamWriter = new StreamWriter(path, true, Encoding.GetEncoding("Shift_JIS"));
        string[] s1 = { "Question", "SelectArrow", "SymbolArrow", "CharArrow", "r or w" ,"Time"};
        var s2 = string.Join(",", s1);
        _streamWriter.WriteLine(s2);
        Debug.Log("Write Title");
    }

    public void EndTask()
    {
        _streamWriter.WriteLine("EndTask");
        Debug.Log("EndTask");
    }

    private void OnApplicationQuit()
    {
        _streamWriter.Close();
        Debug.Log("Close");
    }

    public void SaveData(string question, string selectArrow, string symbolArrow, string charArrow, string time)
    {
        photonView.RPC(nameof(RpcSaveData), RpcTarget.Others, question, selectArrow, symbolArrow, charArrow, time);
    }
    
    public void SaveCount()
    {
        photonView.RPC(nameof(RpcSaveCount), RpcTarget.Others);
    }

    private void WriteCount(string count)
    {
        photonView.RPC(nameof(RpcWriteCount), RpcTarget.Others, count);
    }
    
    
    [PunRPC]
    private void RpcSaveData(string question, string selectArrow, string symbolArrow, string charArrow, string time)
    {
        var correct = question switch
        {
            "symbol" => selectArrow == symbolArrow ? "correct" : "wrong",
            "char" => selectArrow == charArrow ? "correct" : "wrong",
            _ => null
        };
        string[] s1 = { question, selectArrow, symbolArrow, charArrow, correct, time};
        var s2 = string.Join(",", s1);
        _streamWriter.WriteLine(s2);
    }
    
    [PunRPC]
    private void RpcSaveCount()
    {
        WriteCount(primaryButtonReactor.count.ToString());
        primaryButtonReactor.count = 0;
    }
    
    [PunRPC]
    private void RpcWriteCount(string count)
    {
        string[] s1 = { count };
        var s2 = string.Join(",", s1);
        _streamWriter.WriteLine(s2);
    }
}
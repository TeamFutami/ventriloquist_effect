using System;
using System.IO;
using Cysharp.Threading.Tasks;
using Nekomimi.Daimao;
using UnityEngine;

public class LogExporter : MonoBehaviour
{
    private void Start()
    {
        // /Assets/StreamingAssets/log/example.txt
        var fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
        var path = Path.Combine(Application.streamingAssetsPath, "log", $"{fileName}.txt");
        var logWriter = new LogWriter(path, this.GetCancellationTokenOnDestroy());
    }
}

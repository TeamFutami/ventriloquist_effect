using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Nekomimi.Daimao
{
    public class LogWriter
    {
        /// <summary>
        /// LogFilePath
        /// </summary>
        public readonly string LogPath;

        public LogWriter(string logPath, CancellationToken cancellationToken)
        {
            this.LogPath = logPath;
            Application.logMessageReceivedThreaded += OnLogMessageReceivedThreaded;
            LogWriteLoop(cancellationToken).Forget();
        }

        private readonly Dictionary<int, string> logLevelCase = new Dictionary<int, string>()
        {
            {(int) LogType.Error, "E"},
            {(int) LogType.Assert, "A"},
            {(int) LogType.Warning, "W"},
            {(int) LogType.Log, "L"},
            {(int) LogType.Exception, "Ex"},
        };

        private const string DateTimeFormat = "yyyyMMddHHmmss";

        private void OnLogMessageReceivedThreaded(string condition, string stacktrace, LogType type)
        {
            logQueue.Add($"{DateTimeOffset.Now.ToString(DateTimeFormat)} [{logLevelCase[(int) type]}] {condition}");
        }

        private readonly BlockingCollection<string> logQueue = new BlockingCollection<string>(new ConcurrentQueue<string>());

        private async UniTaskVoid LogWriteLoop(CancellationToken cancellationToken)
        {
            StreamWriter streamWriter = null;
            try
            {
                var parentDir = new FileInfo(LogPath).Directory;
                if (parentDir != null && !parentDir.Exists)
                {
                    parentDir.Create();
                }

                streamWriter = new StreamWriter(LogPath, true, Encoding.UTF8);

                while (true)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                    await UniTask.SwitchToThreadPool();
                    var log = logQueue.Take(cancellationToken);
                    await streamWriter.WriteLineAsync(log);
                }
            }
            finally
            {
                if (streamWriter != null)
                {
                    await streamWriter.FlushAsync();
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }
    }
}

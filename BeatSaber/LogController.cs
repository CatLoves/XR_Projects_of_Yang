using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    private static ILogger _logger = Debug.unityLogger;
    private static string _log_tag = "MyLoggingTag";
    // Start is called before the first frame update
    void Start()
    {
        if (Debug.isDebugBuild)
        {
            _logger.filterLogType = LogType.Warning;
            _logger.LogWarning(_log_tag,"=> Logging level: Warning");
        }
        else
        {
            _logger.filterLogType = LogType.Warning;
            _logger.LogWarning(_log_tag, "=> Logging level: Warning");
        }
    }

    public static void LogWarning(string msg)
    {
        _logger.LogWarning(_log_tag, msg);
    }
    
    public static void LogError(string msg)
    {
        _logger.LogError(_log_tag, msg);
    }
    
}

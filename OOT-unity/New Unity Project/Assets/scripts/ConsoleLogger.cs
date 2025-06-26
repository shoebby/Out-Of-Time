using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConsoleLogger : Singleton<ConsoleLogger>
{
    uint qsize = 1;  // number of messages to keep
    Queue myLogQueue = new Queue();
    [SerializeField] private string startLog;
    [SerializeField] private Texture2D logBackground;
    [SerializeField] private Font logFont;

    private float log_ypos = 1030;
    private float log_height = 50;
    private int fontSize = 20;

    private Color fontColor;

    void Start()
    {
        Debug.LogError(startLog);
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error)
        {
            fontColor = Color.red;
        }

        else if (type == LogType.Warning)
        {
            fontColor = Color.yellow;
        }
        else if (type == LogType.Log)
        {
            fontColor = Color.white;
        }

        myLogQueue.Enqueue("<b>[" + type + "] :</b> " + logString);
        if (type == LogType.Exception)
            myLogQueue.Enqueue(stackTrace);
        while (myLogQueue.Count > qsize)
            myLogQueue.Dequeue();
    }

    void OnGUI()
    {
        GUIStyle gStyle = new GUIStyle();
        gStyle.normal.background = logBackground;
        gStyle.normal.textColor = fontColor;
        gStyle.fontSize = fontSize;
        gStyle.font = logFont;

        GUILayout.BeginArea(new Rect(0, log_ypos, Screen.width, log_height), gStyle);
        GUILayout.Label("\n" + string.Join("\n", myLogQueue.ToArray()),gStyle);
        GUILayout.EndArea();
    }

    public void MakeLog(string log, LogType type)
    {
        if (type == LogType.Error)
        {
            Debug.LogError(log);
        }
        else if (type == LogType.Warning)
        {
            Debug.LogWarning(log);
        }
        else if (type == LogType.Log)
        {
            Debug.Log(log);
        }
    }
}

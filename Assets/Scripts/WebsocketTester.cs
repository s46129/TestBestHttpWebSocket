using System;
using Best.WebSockets;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WebsocketTester : MonoBehaviour
{
    private WebSocket _webSocket;
    public string wsLocalhost = "ws://localhost:8080";

    [FormerlySerializedAs("receivedText")] [SerializeField]
    private Text DebugText;

    void Start()
    {
        Connect();
    }

    public void Connect()
    {
        _webSocket = new WebSocket(new Uri(wsLocalhost));
        _webSocket.OnOpen += OnWebSocketOpen;
        _webSocket.OnMessage += OnMessageReceived;
        _webSocket.OnClosed += OnWebSocketClosed;

        _webSocket.Open();
    }

    private void OnWebSocketOpen(WebSocket webSocket)
    {
        UpdateText("WebSocket is now Open!");
    }

    private void OnWebSocketClosed(WebSocket websocket, WebSocketStatusCodes code, string message)
    {
        _webSocket.OnOpen -= OnWebSocketOpen;
        _webSocket.OnMessage -= OnMessageReceived;
        _webSocket.OnClosed -= OnWebSocketClosed;
        UpdateText("WebSocket is Closed!");
    }

    private void OnMessageReceived(WebSocket websocket, string message)
    {
        UpdateText(message);
    }


    public new void SendMessage(string message)
    {
        _webSocket.Send(message);
        UpdateText("Send :" + message);
    }

    private void UpdateText(string message)
    {
        DebugText.text += $"\n{message}";
    }
}
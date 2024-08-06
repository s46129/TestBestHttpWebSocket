using System;
using Best.WebSockets;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WebsocketTester : MonoBehaviour
{
    private WebSocket _webSocket;

    [FormerlySerializedAs("receivedText")] [SerializeField]
    private Text DebugText;


    public void Connect(string wsLocalhost)
    {
        _webSocket = new WebSocket(new Uri(wsLocalhost));
        _webSocket.OnOpen += OnWebSocketOpen;
        _webSocket.OnMessage += OnMessageReceived;
        _webSocket.OnClosed += OnWebSocketClosed;

        _webSocket.Open();
    }

    public void Disconnect()
    {
        if (_webSocket == null)
        {
            return;
        }

        _webSocket.OnOpen -= OnWebSocketOpen;
        _webSocket.OnMessage -= OnMessageReceived;
        _webSocket.OnClosed -= OnWebSocketClosed;
        _webSocket.Close();
        _webSocket = null;
    }

    private void OnWebSocketOpen(WebSocket webSocket)
    {
        UpdateText("WebSocket is now Open!");
    }

    private void OnWebSocketClosed(WebSocket websocket, WebSocketStatusCodes code, string message)
    {
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
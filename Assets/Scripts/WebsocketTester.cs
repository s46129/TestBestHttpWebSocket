using System;
using Best.WebSockets;
using UnityEngine;

public class WebsocketTester : MonoBehaviour
{
    private WebSocket _webSocket;
    public string wsLocalhost = "ws://localhost:8080";

    void Start()
    {
        _webSocket = new WebSocket(new Uri(wsLocalhost));
        _webSocket.OnOpen += OnWebSocketOpen;
        _webSocket.OnMessage += OnMessageReceived;
        _webSocket.OnClosed += OnWebSocketClosed;

        _webSocket.Open();
    }

    private void OnWebSocketOpen(WebSocket webSocket)
    {
        Debug.Log("WebSocket is now Open!");
    }

    private void OnWebSocketClosed(WebSocket websocket, WebSocketStatusCodes code, string message)
    {
        Debug.Log("WebSocket is now Closed!");
    }

    private void OnMessageReceived(WebSocket websocket, string message)
    {
        Debug.Log("Received:" + message);
    }


    private void SendMessage(string message)
    {
        Debug.Log("Send :" + message);
        _webSocket.Send(message);
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

public class SendMessageTester : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    [SerializeField] private Button button;

    [SerializeField] private WebsocketTester websocketTester;

    private void Awake()
    {
        button.onClick.AddListener(Send);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Send();
        }
    }

    void Send()
    {
        var inputFieldText = inputField.text;
        websocketTester.SendMessage(inputFieldText);
        inputField.text = "";
    }
}
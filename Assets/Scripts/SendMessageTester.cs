using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SendMessageTester : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    [SerializeField] private Button button;

    [SerializeField] private WebsocketTester websocketTester;

    private void Awake()
    {
        button.onClick.AddListener(SendMessage);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnKeyboardEnter();
        }
    }

    private void OnKeyboardEnter()
    {
        SendMessage();
        EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
        // 避免出現鍵盤在不必要的時候彈出
        inputField.OnPointerClick(new PointerEventData(EventSystem.current));
    }

    private void SendMessage()
    {
        var inputFieldText = inputField.text;
        websocketTester.SendMessage(inputFieldText);
        inputField.text = "";
    }
}
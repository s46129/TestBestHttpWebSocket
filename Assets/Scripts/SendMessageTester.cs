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

    void Send()
    {
        var inputFieldText = inputField.text;
        websocketTester.SendMessage(inputFieldText);
        inputField.text = "";
    }
}
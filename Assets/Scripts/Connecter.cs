using UnityEngine;
using UnityEngine.UI;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEngine.Serialization;

public class Connecter : MonoBehaviour
{
    [SerializeField] private WebsocketTester _websocketTester;
    [SerializeField] private InputField iPInputField;

    [FormerlySerializedAs("_button")] [SerializeField]
    private Button button;

    private string _ipAddress;
    private string _ipaddressKey = "IPAddress";

    private void Awake()
    {
        _ipAddress = PlayerPrefs.GetString(_ipaddressKey, "ws://127.0.0.1:8080");

        iPInputField.text = _ipAddress;
        CheckIP(_ipAddress);
        Connect();
        iPInputField.onValueChanged.AddListener(CheckIP);
        button.onClick.AddListener(Connect);
    }

    private void Connect()
    {
        if (string.IsNullOrEmpty(_ipAddress))
        {
            return;
        }

        _websocketTester.Disconnect();

        _websocketTester.Connect(_ipAddress);
    }

    private void CheckIP(string value)
    {
        button.interactable = !string.IsNullOrEmpty(value);
        _ipAddress = iPInputField.text;
        PlayerPrefs.SetString(_ipaddressKey, _ipAddress);
    }
}
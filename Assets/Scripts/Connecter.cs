using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.Commands.CheckIn;
using UnityEngine;
using UnityEngine.UI;

public class Connecter : MonoBehaviour
{
    [SerializeField] private WebsocketTester _websocketTester;
    [SerializeField] private InputField iPInputField;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.interactable = false;
        iPInputField.onValueChanged.AddListener(CheckIP);

        _button.onClick.AddListener(() =>
        {
            if (string.IsNullOrEmpty(iPInputField.text))
            {
                return;
            }

            _websocketTester.wsLocalhost = iPInputField.text;
            _websocketTester.Disconnect();
            _websocketTester.Connect();
        });
    }

    private void CheckIP(string value)
    {
        _button.interactable = !string.IsNullOrEmpty(value);
    }
}
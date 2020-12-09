﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DeveloperConsoleBehaviour : MonoBehaviour
{
    private string prefix = "";
    [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

    [Header("UI")]
    [SerializeField] private GameObject uiCanvas = null;
    [SerializeField] private TMP_InputField inputField = null;

    public ScrollRect scrollRect;
    public TMP_Text consoleText;

    private static string code;

    private static DeveloperConsoleBehaviour instance;

    private DeveloperConsole developerConsole;
    private DeveloperConsole DeveloperConsole
    {
        get
        {
            if (developerConsole != null) { return developerConsole; }
            return developerConsole = new DeveloperConsole(prefix, commands);
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void LateUpdate() {
        
        
        if(Input.GetKeyDown(KeyCode.Return))
        {
            //DeveloperConsole.ProcessCommand(inputField.text);
            GameManager.IsMovable = true;
        }

        if(GameManager.IsMovable)
        {
            //Debug.Log("IsMovable");

            DeveloperConsole.ProcessCommand(code);
        }


        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (uiCanvas.activeSelf)
            {
                uiCanvas.SetActive(false);
            }
            else
            {
                uiCanvas.SetActive(true);
                inputField.ActivateInputField();
            }
        }
            
    }

    // public void Toggle()
    // {
    //     //if (!context.action.triggered) { return; }

    //     if (uiCanvas.activeSelf)
    //     {
    //         uiCanvas.SetActive(false);
    //     }
    //     else
    //     {
    //         uiCanvas.SetActive(true);
    //         inputField.ActivateInputField();
    //     }
    // }

    public void ProcessCommand(string inputValue)
    {
        code = inputValue;
        //DeveloperConsole.ProcessCommand(inputValue);
        AddMessageToConsole(code);

        inputField.text = string.Empty;
    }

    public void AddMessageToConsole (string msg)
    {
        consoleText.text += msg + "\n";
        scrollRect.verticalNormalizedPosition = 0f;
    }
 
    public static void AddStaticMessageToConsole (string msg)
    {
        // DeveloperConsole.Instance.consoleText.text += msg + "\n";
        // DeveloperConsole.Instance.scrollRect.verticalNormalizedPosition = 0f;
    }
}

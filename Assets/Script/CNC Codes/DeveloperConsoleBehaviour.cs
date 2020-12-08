using TMPro;
using UnityEngine;


public class DeveloperConsoleBehaviour : MonoBehaviour
{
    private string prefix = "";
    [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

    [Header("UI")]
    [SerializeField] private GameObject uiCanvas = null;
    [SerializeField] private TMP_InputField inputField = null;

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
            Debug.Log("IsMovable");

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

        inputField.text = string.Empty;
    }
}


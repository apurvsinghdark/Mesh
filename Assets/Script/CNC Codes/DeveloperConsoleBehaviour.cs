using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DeveloperConsoleBehaviour : MonoBehaviour
{   
    private string prefix = "";
    [Header("ConsoleCommands")]
    [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

    [Header("UI")]
    [SerializeField] private GameObject uiCanvas = null;
    [SerializeField] private TMP_InputField inputField = null;

    public ScrollRect scrollRect;
    public TMP_Text consoleText;

    [Header("CodeListContainer")]
    [SerializeField] private CodeListContainers containers;
    //[SerializeField] private GCodeList gList;

    ///PROCESS COMMANDS HELPER
    string code = "";
    string[] textSplit;
    string Commandtext;

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

    private void Start() {
        //InputCommand.instance.OnEnterChanged += TextToConsole;
        InputCommand.instance.OnEnterChanged += OnClickList;
        InputCommand.instance.OnCycleStartChanged += StartCycle;
        InputCommand.instance.OnProgramList += ReadFromUsb;

        //StartCoroutine(ReadFromUsb());
        //OnClickList();
    }
    private void LateUpdate() {
        
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

    private void Update() {
        //ReadFromUsb();
    }

    void ReadFromUsb()
    {
        for (int i = 0; i < containers.lists.Length; i++)
        {
            //print(containers.gCodeLists[i] + " " + i);
            //StartCoroutine(ListRead(containers.gCodeLists[i]));
            consoleText.text += containers.lists[i].listName + "\n";
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }

    public void OnClickList()
    {
        if(ArrowKeys.listID > containers.lists.Length - 1)
        {
            ArrowKeys.listID = containers.lists.Length - 1;
        }
        ///For multiple Cnc Program
        StartCoroutine(ListRead(containers.lists[ArrowKeys.listID].gCodeLists));
        
        //For First Cnc Programe
        //StartCoroutine(ListRead(containers.lists[0].gCodeLists));
    }

    public void TextToConsole()
    {
        //Debug.Log("Enter Pressed");
        code = InputCommand.instance.myCommand.text;
        AddMessageToConsole(code);
        
        // if(GameManager.IsPower)
        //     DeveloperConsole.ProcessCommand(code);

        InputCommand.instance.myCommand.text = string.Empty;
    }

    public void StartCycle()
    {
        if(GameManager.IsPower)
            StartCoroutine(ListSystem());
    }
    public void ReadList()
    {
        //StartCoroutine(ListRead());
    }

    public void ProcessCommand(string inputValue)
    {
        // code = inputValue;
        
        // if(GameManager.IsPower)
        //     DeveloperConsole.ProcessCommand(code);
        
        // AddMessageToConsole(code);

        // inputField.text = string.Empty;
    }

    public void AddMessageToConsole (string msg)
    {
        //consoleText.text += msg + "\n";
        Commandtext += msg;
        //scrollRect.verticalNormalizedPosition = 0f;

        textSplit = Commandtext.Split(";"[0]);

        //Debug.Log(textSplit[1]);
    }
 
    public static void AddStaticMessageToConsole (string msg)
    {
        // DeveloperConsole.Instance.consoleText.text += msg + "\n";
        // DeveloperConsole.Instance.scrollRect.verticalNormalizedPosition = 0f;
    }


    //Read String Commands at certain interval of time
    IEnumerator ListSystem() {
     
        //yield return new WaitForSeconds(1f);

        for(int i = 0; i < textSplit.Length; i++) {   

            consoleText.text += textSplit[i] + "\n";
            scrollRect.verticalNormalizedPosition = 0f;
            DeveloperConsole.ProcessCommand(textSplit[i]);
            Debug.Log(textSplit[i]);
            
            yield return new WaitForSeconds(5f);
        }
    }    
    
    IEnumerator ListRead(GCodeList gList) {
        consoleText.text = string.Empty;
        
        for(int i = 0; i < gList.CodeList.Length; i++) {   

            AddMessageToConsole(gList.CodeList[i]);
            // print(gList.CodeList[i]);
        
        }
        yield return null;
    }    

}


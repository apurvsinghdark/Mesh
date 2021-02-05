using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class InputCommand : MonoBehaviour
{
    string word = null;
    int worldIndex = 0;
    
    //For ResetButton
    int buttonClick = 0;
    
    //For EnterButton
    int _Pressed = 0;


    string alpha;
    public TMP_Text myCommand = null;
    public TMP_Text instructionText = null;

    public delegate void OnResetChanged();
    public OnResetChanged onResetChanged;

    public event System.Action OnPowerOnChanged;
    public event System.Action OnPowerOffChanged;
    public event System.Action OnPowerChanged;
    public event System.Action OnEStopChanged;
    public event System.Action OnEnterChanged;
    public event System.Action OnCycleStartChanged;
    public event System.Action OnProgramList;

    public void alphabetFunction(string alphabet)
    {
        worldIndex++;
        word = word + alphabet;
        myCommand.text = word;
    }

    public static InputCommand instance;

    private void Awake() {
        
        if (instance == null)
        {
            instance = this;
        }
    }

    public void RESETALL()
    {
        //Debug.Log("Reset");
        buttonClick += 1;
        if(buttonClick == 2)
        {
            if(onResetChanged != null)
            {
                onResetChanged.Invoke();
                instructionText.text = "Press Power up resart button";
                Debug.Log("Reset");
                buttonClick = 0;
            }
        }
    }
    
    public void EmergencyStop()
    {
        if(OnEStopChanged != null)
            OnEStopChanged();
    }
    
    public void PowerSwitch()
    {
        if(OnPowerChanged != null)
            OnPowerChanged();
    }
    public void PowerOnSwitch()
    {
        if(OnPowerOnChanged != null)
            OnPowerOnChanged();
    }
    public void PowerOffSwitch()
    {
        if(OnPowerOffChanged != null)
            OnPowerOffChanged();
    }

    public void OnEnter()
    {
        if(_Pressed == 2)
        {
            if(OnEnterChanged != null)
                OnEnterChanged();
        }
        _Pressed += 1;
    }
    
    public void OnCycleStart()
    {
        if(OnCycleStartChanged != null)
            OnCycleStartChanged();
    }

    public void OnCancel()
    {
        word = string.Empty;
        myCommand.text = string.Empty;
    }

    public void ProgramList()
    {
        if(OnProgramList != null)
            OnProgramList();
    }
}

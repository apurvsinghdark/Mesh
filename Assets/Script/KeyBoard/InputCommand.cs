using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class InputCommand : MonoBehaviour
{
    string word = null;
    int worldIndex = 0;
    string alpha;
    public TMP_Text myCommand = null;

    public delegate void OnResetChanged();
    public OnResetChanged onResetChanged;ChanonResetChanged != null

    public event System.Action OnPowerChanged;
    public event System.Action OnEStopChanged;

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
        Debug.Log("Reset");

        if(onResetChanged != null)
            onResetChanged.invoke();
    }
    
    public void EmergencyStop()
    {
        Debug.Log("E-STOP");

        if(OnEStopChanged != null)
            OnEStopChanged();
    }
    
    public void PowerSwitch()
    {
        Debug.Log("Power");

        if(OnPowerChanged != null)
            OnPowerChanged();
    }
}

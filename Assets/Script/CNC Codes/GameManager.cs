using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region singleton
    public static GameManager instance;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public Transform pin;
    public Transform meshHolder;

    //Turrent_Transforms
    public Transform turrent;
    public Transform turrent_toolHolder;

    public Transform cylinder;
    public Transform chuck;

    public float spindleRate;

    public static bool IsMovable { get; set;}
    public static bool IsPower { get; set;}

    private void Start() {
        
        IsMovable = false;
        IsPower = false;

        InputCommand.instance.OnEStopChanged += OnEStop;
        InputCommand.instance.OnPowerChanged += OnPower;
        InputCommand.instance.onResetChanged += OnReset;
        InputCommand.instance.OnPowerOnChanged += PowerOnn;
        InputCommand.instance.OnPowerOffChanged += PowerOff;
    }

    private void Update() {
        
        cylinder.Rotate(spindleRate,0,0);
        chuck.Rotate(-spindleRate/2.5f,0,0);

        //pin.localPosition = new Vector3(turrent.localPosition.x, pin.localPosition.y, pin.localPosition.z);

    }

    public void OnEStop()
    {
        Debug.Log("E-STOP form Gamemanager");
        spindleRate = 0;
        IsMovable = false;
        IsPower = false;
    }
    public void OnPower()
    {
        IsPower = !IsPower;

        if(IsPower)
        {
            Debug.Log("Power On");
        }
        else
        {
            Debug.Log("Power Off");
        }
    }

    public void PowerOnn()
    {
        IsPower = true;
        Debug.Log("Power On");
    }
    
    public void PowerOff()
    {
        IsPower = false;
        Debug.Log("Power Off");
    }

    public void OnReset()
    {
        //pin.position = new Vector3(6,-7,0);
    }
}

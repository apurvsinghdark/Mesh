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
    public Transform cylinder;

    public static float spindleRate;

    public static bool IsMovable { get; set;}
    public static bool IsPower { get; set;}

    private void Start() {
        
        IsMovable = false;
        IsPower = false;

        InputCommand.instance.OnEStopChanged += OnEStop;
        InputCommand.instance.OnPowerChanged += OnPower;
    }

    private void Update() {
        
        cylinder.Rotate(spindleRate,0,0);
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
}

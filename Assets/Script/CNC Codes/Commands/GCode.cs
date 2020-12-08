using UnityEngine;

[CreateAssetMenu(fileName = "New GCODES", menuName = "Commands/GCodes")]
public class GCode : ConsoleCommand
{
    public string msg = " ";
    
    public override bool Process(string[] args)
    {
        if (args.Length != 1) { return false; }

        if (!float.TryParse(args[0], out float value))
        {
            return false;
        }

        //Debug.Log(msg + " " + value);

        GameManager Pin = GameManager.instance;
        Pin.pin.position = new Vector3(-value, 0, 1);


        if (Pin.pin.position == new Vector3(-value, 0, 1))
        {
            GameManager.IsMovable = false;
        }

        return true;
    }
}


using UnityEngine;

[CreateAssetMenu(fileName = "New GCODES", menuName = "Commands/G01")]
public class G01 : ConsoleCommand
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
        Pin.pin.position = Vector3.MoveTowards(Pin.pin.position, new Vector3(-value , 0, 1), 5 * Time.deltaTime);

        if (Pin.pin.position == new Vector3(-value, 0, 1))
        {
            GameManager.IsMovable = false;
        }
        //Pin.pin.position.x 
    

        return true;
    }
}


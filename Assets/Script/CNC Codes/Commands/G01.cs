using UnityEngine;

[CreateAssetMenu(fileName = "New GCODES", menuName = "Commands/G01")]
public class G01 : ConsoleCommand
{
    public string msg = " ";

    string[] textSplit;

    
    public override bool Process(string[] args)
    {
        //if (args.Length != 1) { return false; }

        // if (!float.TryParse(args[0], out float value))
        // {
        //     return false;
        // }

        string logText = string.Join(" ", args);

        textSplit = logText.Split(" "[0]);

        var x = textSplit[0].Remove(0,1);
        var z = textSplit[1].Remove(0,1);

        if (!float.TryParse(x, out float xValue))
        {
            return false;
        }
        
        if (!float.TryParse(z, out float zValue))
        {
            return false;
        }

        //Debug.Log(msg + " " + value);

        GameManager Pin = GameManager.instance;
        Pin.pin.position = Vector3.MoveTowards(Pin.pin.position, new Vector3(xValue , zValue, 0), 5 * Time.deltaTime);

        if (Pin.pin.position == new Vector3(xValue, zValue, 0))
        {
            GameManager.IsMovable = false;
        }
        //Pin.pin.position.x 
    

        return true;
    }
}


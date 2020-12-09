using UnityEngine;

[CreateAssetMenu(fileName = "New GCODES", menuName = "Commands/GCodes")]
public class GCode : ConsoleCommand
{
    public string msg = " ";

    string[] textSplit;

    
    public override bool Process(string[] args)
    {
        //if (args.Length != 1) { return false; }

        string logText = string.Join(" ", args);

        textSplit = logText.Split(" "[0]);

        // for(int i = 0; i < textSplit.Length; i++){
        //      //Debug.Log(textSplit[i]); //each split
        // }

        var x = textSplit[0].Remove(0,1);
        var z = textSplit[1].Remove(0,1);
        
        //Debug.Log(x);
        //Debug.Log(z);

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
        Pin.pin.position = new Vector3(-xValue, zValue, 1);


        if (Pin.pin.position == new Vector3(-xValue, zValue, 1))
        {
            GameManager.IsMovable = false;
        }

        return true;
    }
}


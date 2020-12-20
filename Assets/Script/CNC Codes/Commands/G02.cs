using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New GCODES", menuName = "Commands/G02")]
public class G02 : ConsoleCommand
{
    public static G02 instance;
    public string msg = " ";

    private Vector2 chisel;
    private Vector2 end;

    string[] textSplit;

    private void Awake() {
        
        if(instance == null)
        {
            instance = this;
        }
    }

    public event System.Action<Transform, Vector2, Vector2, float, float> FollowCircle;

    public override bool Process(string[] args)
    {

        string logText = string.Join(" ", args);

        textSplit = logText.Split(" "[0]);

        var x = textSplit[0].Remove(0,1);
        var z = textSplit[1].Remove(0,1);
        var r = textSplit[2].Remove(0,1);
 
        if (!float.TryParse(x, out float xValue))
        {
            return false;
        }
        
        if (!float.TryParse(z, out float zValue))
        {
            return false;
        }
        
        if (!float.TryParse(r, out float rValue))
        {
            return false;
        }

        //Debug.Log(msg + " " + value);

        GameManager Pin = GameManager.instance;

        chisel.x = Pin.pin.position.x;
        chisel.y = Pin.pin.position.y;

        end.x = zValue;
        end.y = xValue;

        //FollowArc(Pin.pin, chisel, end, rValue, 3);
        if(FollowCircle != null)
        {
            FollowCircle(Pin.pin, chisel, end, rValue, 3);
        }
        

        return true;
    }
}

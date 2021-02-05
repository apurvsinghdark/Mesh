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

    public event System.Action<Transform , Vector2, Vector2, float, float> FollowCircle;
    //public event System.Action FollowCircle;

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

        chisel.x = Pin.pin.localPosition.x;
        chisel.y = Pin.pin.localPosition.y;

        float percentZValue = (zValue/100) * 75f;
        float percentXValue = (xValue/100) * 75f;
        //Debug.Log(percentValue);
        float newXPosition = -140.4f - percentZValue;
        float newYPosition = -3f - percentXValue;

        // end.x = -32.86f;
        // end.y = -4.900002f;
        
        end.x = newXPosition;
        end.y = newYPosition;

        if(rValue == 2)
        {
            rValue = 5;
        }

        if(FollowCircle != null)
        {
            FollowCircle(Pin.pin, chisel, end, rValue, 10);
            // FollowCircle(xValue, zValue, rValue, 30);
            // FollowCircle();
        }
        

        return true;
    }
}

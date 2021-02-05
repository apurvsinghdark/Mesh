using UnityEngine;

[CreateAssetMenu(fileName = "New GCODES", menuName = "Commands/G00")]
public class G00 : ConsoleCommand
{
    public string msg = " ";

    string[] textSplit;
    public static bool IsVertical {get; set;}

    public event System.Action<float, float> QuickMovement;
    
    public override bool Process(string[] args)
    {
        string logText = string.Join(" ", args);
        
        textSplit = logText.Split(" "[0]);
        
        if(string.Compare(textSplit[0], 0, "Z", 0, 1) == 0)
        {
            IsVertical = false;
            var z = textSplit[0].Remove(0,1);

            if (!float.TryParse(z, out float zValue))
            {
                return false;
            }

            if(QuickMovement != null)
            {
                QuickMovement(0, zValue); 
            }

            return true;
        }

        if(string.Compare(textSplit[0], 0, "X", 0, 1) == 0)
        {
            IsVertical = true;
            
            var x = textSplit[0].Remove(0,1);

            if (!float.TryParse(x, out float xValue))
            {
                return false;
            }

            if(QuickMovement != null)
            {
                QuickMovement(xValue, 0); 
            }

            return true;
        }

        //Debug.Log(msg + " " + value);
        if(textSplit[0] != null && textSplit[1] != null)
        {
            var z = textSplit[0].Remove(0,1);

            if (!float.TryParse(z, out float zValue))
            {
                return false;
            }

            var x = textSplit[0].Remove(0,1);

            if (!float.TryParse(x, out float xValue))
            {
                return false;
            }

            if(QuickMovement != null)
            {
                QuickMovement(xValue, zValue); 
            }

            return true;
        }

        return true;
    }
}


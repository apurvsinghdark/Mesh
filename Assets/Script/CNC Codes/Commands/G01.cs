using UnityEngine;

[CreateAssetMenu(fileName = "New GCODES", menuName = "Commands/G01")]
public class G01 : ConsoleCommand
{
    public string msg = " ";

    string[] textSplit;
    public static bool IsHorizontal = true;
    public static bool IsSingle = true;
    public static bool IsChamfer = false;

    public event System.Action<float, float, float> LinearMovement;
    
    public override bool Process(string[] args)
    {
        string logText = string.Join(" ", args);

        textSplit = logText.Split(" "[0]);

        if(string.Compare(textSplit[0], 0, "Z", 0, 1) == 0 && string.Compare(textSplit[1], 0, "F", 0, 1) == 0)
        {
            IsHorizontal = true;
            IsSingle = true;

            var z = textSplit[0].Remove(0,1);

            if (!float.TryParse(z, out float zValue))
            {
                return false;
            }

            var f = textSplit[1].Remove(0,1);
            
            if (!float.TryParse(f, out float fValue))
            {
                return false;
            }

            //Debug.Log(msg + " " + value);

            if(LinearMovement != null)
            {
                LinearMovement(0, zValue, fValue); 
            }

            return true;
        }

        if(string.Compare(textSplit[0], 0, "X", 0, 1) == 0 && string.Compare(textSplit[1], 0, "F", 0, 1) == 0)
        {
            IsHorizontal = false;
            IsSingle = true;
            
            var x = textSplit[0].Remove(0,1);

            if (!float.TryParse(x, out float xValue))
            {
                return false;
            }

            var f = textSplit[1].Remove(0,1);
            
            if (!float.TryParse(f, out float fValue))
            {
                return false;
            }

            //Debug.Log(msg + " " + value);

            if(LinearMovement != null)
            {
                LinearMovement(xValue, 0, fValue); 
            }

            return true;
        }
        
        if(string.Compare(textSplit[0], 0, "X", 0, 1) == 0 && string.Compare(textSplit[1], 0, "C", 0, 1) == 0)
        {
            IsHorizontal = false;
            IsSingle = true;
            IsChamfer = true;
            
            var x = textSplit[0].Remove(0,1);

            if (!float.TryParse(x, out float xValue))
            {
                return false;
            }

            var c = textSplit[1].Remove(0,1);
            
            if (!float.TryParse(c, out float cValue))
            {
                return false;
            }

            //Debug.Log(msg + " " + value);

            if(LinearMovement != null)
            {
                LinearMovement(xValue, cValue, 10f); 
            }

            return true;
        }

        if(textSplit[2] != null)
        {
            IsSingle = false;

            var x = textSplit[0].Remove(0,1);
            var z = textSplit[1].Remove(0,1);
            var f = textSplit[2].Remove(0,1);

            if (!float.TryParse(x, out float xValue))
            {
                return false;
            }
            
            if (!float.TryParse(z, out float zValue))
            {
                return false;
            }
            
            if (!float.TryParse(f, out float fValue))
            {
                return false;
            }

            //Debug.Log(msg + " " + value);

            if(LinearMovement != null)
            {
                LinearMovement(xValue, zValue, fValue); 
            }

            return true;
        }

        return true;
    }
}
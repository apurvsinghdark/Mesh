using UnityEngine;

[CreateAssetMenu(fileName = "New MCODES", menuName = "Commands/M06")]
public class M06 : ConsoleCommand
{
    public string msg = " ";

    string[] textSplit;

    public event System.Action<float> ToolChange;

    public override bool Process(string[] args)
    {
        string logText = string.Join(" ", args);

        textSplit = logText.Split(" "[0]);

        var t = textSplit[0].Remove(0,1);

        if (!float.TryParse(t, out float tValue))
        {
            return false;
        }
        
        if(ToolChange != null)
        {
            ToolChange(tValue);
        }
        //GameManager.instance.spindleRate = sValue/10;
        
        return true;
    }
}

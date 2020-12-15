using UnityEngine;

[CreateAssetMenu(fileName = "New GCODES", menuName = "Commands/M03")]
public class M03 : ConsoleCommand
{
    public string msg = " ";

    string[] textSplit;

    public override bool Process(string[] args)
    {
        string logText = string.Join(" ", args);

        textSplit = logText.Split(" "[0]);

        var s = textSplit[0].Remove(0,1);

        if (!float.TryParse(s, out float sValue))
        {
            return false;
        }
        
        GameManager.spindleRate = sValue/1000;
        
        return true;
    }
}

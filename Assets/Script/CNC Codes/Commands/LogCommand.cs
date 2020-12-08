using UnityEngine;


[CreateAssetMenu(fileName = "Log Command", menuName = "Commands/Log Command")]
public class LogCommand : ConsoleCommand
{
    public override bool Process(string[] args)
    {
        string logText = string.Join(" ", args);

        Debug.Log(logText);

        return true;
    }
}

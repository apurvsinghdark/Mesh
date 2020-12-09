using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New GCODES", menuName = "Commands/Test")]
public class TestCode : ConsoleCommand
{
    public string msg = " ";
    string[] textSplit;
    //float x;

    
    public override bool Process(string[] args)
    {
        string logText = string.Join(" ", args);
        //int x;

        textSplit = logText.Split(" "[0]);

        for(int i = 0; i < textSplit.Length; i++){
             //Debug.Log(textSplit[i]); //each split
        }

        var x = textSplit[1].Remove(0,1);
        var z = textSplit[2].Remove(0,1);
        
        Debug.Log(x);
        Debug.Log(z);

        return true;
    }
}

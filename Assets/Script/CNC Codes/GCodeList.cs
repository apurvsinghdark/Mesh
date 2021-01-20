using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GCodesLists", menuName = "List/CodeList")]
public class GCodeList : ScriptableObject
{
    new public string[] CodeList = new string[0];
}

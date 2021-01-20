using UnityEngine;

[CreateAssetMenu(fileName = "Container", menuName = "List/Containers")]
public class CodeListContainers : ScriptableObject
{
    public List[] lists;
}

[System.Serializable]
public struct List
{
    public string listName;
    public GCodeList gCodeLists;
}

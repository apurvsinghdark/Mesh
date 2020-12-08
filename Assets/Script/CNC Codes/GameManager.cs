using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region singleton
    public static GameManager instance;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public Transform pin;

    public static bool IsMovable { get; set;}

    private void Start() {
        
        IsMovable = false;
    }
}

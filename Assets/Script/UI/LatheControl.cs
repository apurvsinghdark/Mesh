using UnityEngine;

public class LatheControl : MonoBehaviour
{
    public static event System.Action PowerUpRestart;
    
    public void PowerUp()
    {
        G01.IsSingle = false;
        if(PowerUpRestart != null)
            PowerUpRestart();
    }
}

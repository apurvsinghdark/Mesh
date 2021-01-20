using UnityEngine;

public class LatheControl : MonoBehaviour
{
    public static event System.Action PowerUpRestart;
    
    public void PowerUp()
    {
        if(PowerUpRestart != null)
            PowerUpRestart();
    }
}

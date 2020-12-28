using UnityEngine;


public class DoorScript : MonoBehaviour
{
    private Animator anim;

    private void Start() {
        
        anim = GetComponent<Animator>();

    }

    private void Update() {

        bool Opening = anim.GetBool("Open");

        if(Input.GetKeyDown(KeyCode.O) && !Opening)
        {
            TriggerDoor();
        }
        else
        if (Input.GetKeyDown(KeyCode.O) && Opening)
        {
            ClosingDoor();
        }

    }

    void TriggerDoor()
    {
        anim.SetBool("Open",true);
    }

    void ClosingDoor()
    {
        anim.SetBool("Open",false);
    }
    
}
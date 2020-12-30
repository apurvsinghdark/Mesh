using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBehaviour : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject aimCamera;
   public GameObject aimReticle;
    
    private void Start() {
        //Input = GetComponent<Playermo>
    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.Z) && !aimCamera.activeInHierarchy)
        {
            mainCamera.SetActive(false);
            aimCamera.SetActive(true);
            Camera.main.orthographic = true;

            //Allow time for the camera to blend before enabling the UI
            StartCoroutine(ShowReticle());
        }
        else if(Input.GetKeyDown(KeyCode.Z) && !mainCamera.activeInHierarchy)
        {
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);
            aimReticle.SetActive(true);
            Camera.main.orthographic = false;
        }
    }
    
    IEnumerator ShowReticle()
    {
        yield return new WaitForSeconds(0.25f);
        aimReticle.SetActive(false);
    }
}

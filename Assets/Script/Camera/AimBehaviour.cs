using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBehaviour : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject standardCamera;
    public GameObject aimCamera;
    public GameObject inspectionCamera;
    public GameObject aimReticle;
    public GameObject inspectionView;
    
    private void Start() {
        //Input = GetComponent<Playermo>
    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.Z) && !aimCamera.activeInHierarchy)
        {
            //Allow time for the camera to blend before enabling the UI
            StartCoroutine(ShowReticle());
            
            standardCamera.SetActive(false);
            aimCamera.SetActive(true);
            inspectionCamera.SetActive(false);
            inspectionView.SetActive(false);

            Camera.main.orthographic = true;
            //mainCamera.SetActive(false);

        }
        else if(Input.GetKeyDown(KeyCode.Z) && !standardCamera.activeInHierarchy)
        {
            //mainCamera.SetActive(true);
            standardCamera.SetActive(true);
            aimCamera.SetActive(false);
            inspectionCamera.SetActive(false);
            inspectionView.SetActive(false);

            aimReticle.SetActive(true);
            Camera.main.orthographic = false;
        }
        else if(Input.GetKeyDown(KeyCode.F) && !inspectionCamera.activeInHierarchy)
        {
            StartCoroutine(ShowReticle());
            
            standardCamera.SetActive(false);
            aimCamera.SetActive(false);
            inspectionCamera.SetActive(true);
            inspectionView.SetActive(true);

            Camera.main.orthographic = false;
            
            mainCamera.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.F) && !mainCamera.activeInHierarchy && !aimCamera.activeInHierarchy)
        {
            mainCamera.SetActive(true);
            standardCamera.SetActive(true);
            aimCamera.SetActive(false);
            inspectionCamera.SetActive(false);
            inspectionView.SetActive(false);
            
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIinspection : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject UICam;
    public GameObject keyBoardUI;
    public GameObject InspectionUI;

    private void Awake() {
        UICam.gameObject.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F) && !UICam.activeInHierarchy)
        {
            mainCamera.SetActive(false);
            keyBoardUI.SetActive(false);
            InspectionUI.SetActive(true);
            UICam.SetActive(true);
            //Camera.main.orthographic = true;

            //Allow time for the camera to blend before enabling the UI
            //StartCoroutine(ShowReticle());
        }
        else if(Input.GetKeyDown(KeyCode.F) && !mainCamera.activeInHierarchy)
        {
            mainCamera.SetActive(true);
            keyBoardUI.SetActive(true);
            InspectionUI.SetActive(false);
            UICam.SetActive(false);
            //Camera.main.orthographic = false;
        }
    }
}

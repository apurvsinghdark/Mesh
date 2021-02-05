using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnterButton : MonoBehaviour
{
    [SerializeField] GameObject enterGlow;
    [SerializeField] GameObject F2;
    [SerializeField] GameObject transferComplete;
    [SerializeField] TMP_Text instructions;
    [SerializeField] GameObject copyProg;
    [SerializeField] GameObject UsbImage;
    [SerializeField] GameObject ProgramList;
    [SerializeField] Button CycleStart;
    [SerializeField] GameObject CycleStartPartiacle;
    [SerializeField] GameObject copyProgM;
    [SerializeField] GameObject ProgramListM;
    [SerializeField] GameObject transferCompleteM;
    [SerializeField] GameObject DiplayPanelM;
    [SerializeField] GameObject BlackPanelM;


    int noofClick = 0;


    public void OnPressEnter()
    {
        if(noofClick == 0)
        {
            instructions.text = "Select the program";
        }else if(noofClick == 1)
        {
            enterGlow.SetActive(false);
            F2.SetActive(true); 
            instructions.text = "Copy the program";
        }else if(noofClick >= 2)
        {
            ProgramList.SetActive(false);
            ProgramListM.SetActive(false);
            transferComplete.SetActive(true);
            transferCompleteM.SetActive(true);
            enterGlow.SetActive(false);
            instructions.text = "Program copied to active memory";
            StartCoroutine(ProcessComplete());
        }
        noofClick += 1;
    }

    IEnumerator ProcessComplete()
    {
        yield return new WaitForSeconds(1f);
        UsbImage.SetActive(true);
        transferComplete.SetActive(false);
        transferCompleteM.SetActive(false);
        instructions.text = "Click on USB to remove it";
        copyProg.SetActive(false);
        copyProgM.SetActive(false);
        DiplayPanelM.SetActive(false);
        BlackPanelM.SetActive(true);
        yield return new WaitForSeconds(0.3f);
    }
}

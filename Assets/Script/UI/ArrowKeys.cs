using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowKeys : MonoBehaviour
{
    float pos = -20f;    
    public static int listID = 0;    

    public Image selectionBar;

    public void UpArrow()
    {
        selectionBar.rectTransform.anchoredPosition = new Vector3(0,pos + 40f,0);
        pos += 40f;
        listID -= 1;
        if(selectionBar.rectTransform.anchoredPosition.y > -20f)
        {
            pos = -20f;
            selectionBar.rectTransform.anchoredPosition = new Vector3(0,pos,0);
            //selectionBar.GetComponent<Image>().enabled = false;
        }
        if(listID < 0)
        {
            listID = 0;
        }
    }
    public void DownArrow()
    {
        selectionBar.rectTransform.anchoredPosition = new Vector3(0,pos - 40f,0);
        pos -= 40f;
        listID += 1;

    }
}

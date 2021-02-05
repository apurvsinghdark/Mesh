using UnityEngine;
using System.Collections;

public class DelayStart : MonoBehaviour
{
    public GameObject[] activeImage;
    public GameObject[] deActiveImage;

    public void StartDelay()
    {
        StartCoroutine(DelayImage());
    }
    IEnumerator DelayImage()
    {
        yield return new WaitForSeconds(0.3f);
        for(int i = 0; i < 2 ; i++)
        {
            activeImage[i].SetActive(false);
            deActiveImage[i].SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInfo : MonoBehaviour {

    public GameObject info;
    public GameObject image;
    private bool disabled = false;

    public void ClickAnimal()
    {
        disabled = true;

        if (disabled == false)
        {
            
        }

        if (disabled == true)
        {
            info.SetActive(true);
            image.SetActive(true);
        }


        
        StartCoroutine(Espera());
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(10);
        info.SetActive(false);
        image.SetActive(false);
    }
}

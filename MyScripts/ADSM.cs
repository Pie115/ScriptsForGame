using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADSM : MonoBehaviour
{
    public GameObject zoomed;
    public GameObject notzoomed;
    public Camera fpsC;
    public Camera ZC;
    private bool isTrue = false;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if(isTrue == false)
            {
                zoomed.gameObject.SetActive(true);
                notzoomed.gameObject.SetActive(false);
                ZC.enabled = true;
                fpsC.enabled = false;
                isTrue = true;
            }
           else if (isTrue == true)
            {
                zoomed.gameObject.SetActive(false);
                notzoomed.gameObject.SetActive(true);
                ZC.enabled = false;
                fpsC.enabled = true;
                isTrue = false;
            }
        }
    }
}

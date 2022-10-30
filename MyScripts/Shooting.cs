using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shooting : MonoBehaviour
{
    private int health = 3;
    public float range = 100f;
    public ParticleSystem muzzleF;
    public Camera fpsCam;
    private int ammo = 10;
    private int clip;
    public TextMeshProUGUI ammodisplay;
    // Update is called once per frame
    private void Start()
    {
        clip = 10;
        ammodisplay.text = (int)clip + " / " + ammo;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && clip > 0)
        {
            Shoot();
            clip--;
            //StartCoroutine(reloadTime());
            ammodisplay.text = (int)clip + " / " + ammo;
        }
        
    }

    void Shoot()
    {
        muzzleF.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TakeDamage takeDamage = hit.transform.GetComponent<TakeDamage>();
            if (takeDamage != null)
            {
                takeDamage.TakeD(1f);
            }
        }
    }

   
    private IEnumerator reloadTime()
    {
        yield return new WaitForSeconds(1.0f);
        if (ammo > 0)
        {
            clip = 1;
            ammo = ammo - 1;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FlashLightController : MonoBehaviour
{
    public AIGoToPlayer AIGoToPlayerScript;
    public GameObject flashlight;
    private bool Switch = true;
    public double battery = 5;
    private AudioSource playerAudio;
    public AudioClip click;
    public AudioClip collect;
    public AudioClip badcollect;
    public TextMeshProUGUI level;
    private double percentage;
    // Update is called once per frame
    void Start()
    {

        playerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        percentage = (battery / 2) * 100;
        level.text = (int)percentage + "%";
        if (Switch == true && battery > 0)
        {
            if (Input.GetKeyDown("f"))
            {

                flashlight.gameObject.SetActive(false);
                playerAudio.PlayOneShot(click, 1.0f);
                Switch = false;
            }
        }
        else if (Switch == false)
        {
            if (Input.GetKeyDown("f"))
            {

                flashlight.gameObject.SetActive(true);
                playerAudio.PlayOneShot(click, 1.0f);
                Switch = true;

            }

        }
        if(Switch == true)
        {

            battery = battery - 0.0001;
        }
        if(battery <=0)
        {
            flashlight.gameObject.SetActive(false);
            Switch = false;
            AIGoToPlayerScript.follow = true;
            AIGoToPlayerScript.timer = 1000000;
            AIGoToPlayerScript.randomPositionGenerator = false;

        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            battery = battery + 1.0;
            playerAudio.PlayOneShot(collect, 2.0f);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Antibattery"))
        {
            battery = battery - 10;
            playerAudio.PlayOneShot(badcollect, 2.0f);
            Destroy(other.gameObject);

        }
    }
}
    



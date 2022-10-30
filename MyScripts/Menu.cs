using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public GameObject Button;
    public GameObject SinglePlayer;
    public bool button;
    
    void Start()
    {
        SceneManager.LoadScene("Final Project v1", LoadSceneMode.Single);
        Debug.Log("Creating SinglePlayer Game");
           
        
    }
    void Update()
    {
        
    }

    void OnClick()
    {
        if (button == true)
        { 
        SceneManager.LoadScene("Final Project v1", LoadSceneMode.Single);
        Debug.Log("bruh");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }
    public void StartBtn(){
        SceneManager.LoadScene("Game");
    }
    public void Quit(){
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

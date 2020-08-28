using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;
    private HealthManager health;
    public PlayerController pc;
    public GameObject gameOverUI, healthDisplay, checkPointDisplay, dialogDisplay;
	static AudioSource asrc;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthManager>();
		asrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if(Input.GetKeyDown(KeyCode.Escape)|| Input.GetButtonDown("Pause")){
            healthDisplay.SetActive(false);
            checkPointDisplay.SetActive(false);
            dialogDisplay.SetActive(false);
			if(GameIsPaused){
				Resume();
			}
			else{
				Pause();
			}
		}
        if(HealthManager.healthAmmount <= 0){
            dialogDisplay.SetActive(false);
			healthDisplay.SetActive(false);
            checkPointDisplay.SetActive(false);
			gameOverUI.SetActive(true);
			asrc.Pause();
			pc.isPause = true;
		}
    }
    public void Resume(){
		asrc.Play();
		pauseMenuUI.SetActive(false);
		healthDisplay.SetActive(true);
		Time.timeScale = 1f;
		pc.isPause = false;
		GameIsPaused = false;
	}void Pause(){
		asrc.Pause();
		pauseMenuUI.SetActive(true);
		pc.isPause = true;
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
    public void ReturnMenu(){
		Reset();
		Time.timeScale = 1f;
		GameIsPaused = false;
		AudioListener.pause = false;
		SceneManager.LoadScene("Menu");
	}
    void Reset(){
		HealthManager.healthAmmount = 5;
	}


}

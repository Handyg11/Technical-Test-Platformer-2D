using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private GameMaster gm;
    public GameObject checkpointText;
    // Start is called before the first frame update
    void Start()
    {
        checkpointText.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
            checkpointText.SetActive(true);
			gm.lastCheckPointPos = other.transform.position;
		}
	}
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            checkpointText.SetActive(false);
        }
    }
}

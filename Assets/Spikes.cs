using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spikes : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController player;
    private GameMaster gm;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Awake()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
            soundManager.PlaySound("playerHit");
			HealthManager.healthAmmount-=1;
			rb.velocity = new Vector2(0.0f,0.0f);
			player.transform.position = gm.lastCheckPointPos;
		}
	}

}

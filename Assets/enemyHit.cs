using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            soundManager.PlaySound("playerHit");
            Destroy(transform.parent.gameObject);
            HealthManager.healthAmmount -=1;
        }
    }
}

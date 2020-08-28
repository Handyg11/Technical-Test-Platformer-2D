using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class enemyZGFX : MonoBehaviour
{
   public  AIPath aIPath;
   public Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(aIPath.desiredVelocity.x >= 0.01f){
            transform.localScale = new Vector3(1f,1f,1f);
        }else if(aIPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(-1f,1f,1f);
        }
    }
    void OnTriggerEnter2D(Collider2D cl){
        if(cl.CompareTag("Player")){
            animator.SetBool("isWalking", true);
        }
    }
    void OnTriggerExit2D(Collider2D cl){
        if(cl.CompareTag("Player")){
            animator.SetBool("isWalking", false);
        }
    }
}

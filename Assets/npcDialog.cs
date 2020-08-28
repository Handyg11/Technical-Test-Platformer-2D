using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcDialog : MonoBehaviour
{
    public GameObject dialog;
    private bool chatAllowed;
    public SpriteRenderer npcRender;
    // Start is called before the first frame update
    void Start()
    {
        npcRender = GetComponent<SpriteRenderer>();
        dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localScale = new Vector3(1f,1f,1f);
        if(chatAllowed && Input.GetButtonDown("Next") ){
            Chat();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            npcRender.flipX = true;
            chatAllowed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            dialog.SetActive(false);
            chatAllowed = false;
        }
    }
    private void Chat(){
        dialog.SetActive(true);
    }
}

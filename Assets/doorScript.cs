using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class doorScript : MonoBehaviour
{
    public GameObject dialog;
    private bool chatAllowed;
    // Start is called before the first frame update
    void Start()
    {
        dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(chatAllowed && Input.GetButtonDown("Next") ){
            Chat();
            StartCoroutine(NextLevel());
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
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
    IEnumerator NextLevel(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level2");
    }
}

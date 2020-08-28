using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typeSpeed;
    public GameObject continueButton, dialogDisplay, healthDisplay;

    void Start()
    {
        StartCoroutine(Type());
        healthDisplay.SetActive(false);
    }
    void Update() {
        healthDisplay.SetActive(false);
        if(textDisplay.text == sentences[index]){
            continueButton.SetActive(true);
            if(Input.GetButtonDown("Next")){
                NextSentence();
            }
        }
    }
    IEnumerator Type(){
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void NextSentence(){
        continueButton.SetActive(false);
            if(index < sentences.Length - 1){
                index++;
                textDisplay.text = "";
                StartCoroutine(Type());
            }else{
                index = 2;
                textDisplay.text = ". . .";
                healthDisplay.SetActive(true);
                continueButton.SetActive(true);
                dialogDisplay.SetActive(false);
        }
    }
}

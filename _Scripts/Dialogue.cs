using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public GameObject dialogueBox;
    public Text dialogueText;
    public string[] sentences;
    public bool dialogueActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the user clicks x when near the interactable character then start the dialogue 
        if(Input.GetKeyDown(KeyCode.X) && dialogueActive)
        {
            if(dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            } 
            
            else
            {
                dialogueBox.SetActive(true);
                StartCoroutine(DisplaySentences());
            }
        }
    }

    IEnumerator DisplaySentences()
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            yield return new WaitForSeconds(3);
            dialogueText.text = sentences[i];
        }
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueActive = false;
            dialogueBox.SetActive(false);
        }
    }

}

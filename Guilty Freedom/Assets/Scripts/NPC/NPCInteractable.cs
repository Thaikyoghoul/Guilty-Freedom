using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string InteractText;
    [SerializeField] private string[] dialogues;
    
    public TextMeshProUGUI nameText;

    public string name;

    public GameObject dialogue;
    private Dialogue dialogueComponent;

    public bool isInteracting = false;

    void start(){
        dialogueComponent = dialogue.GetComponent<Dialogue>();
    }

    void Update(){
        try{
            if(dialogueComponent.done){
            isInteracting = false;
            }
        }catch{

        }
        
    }
    public void Interact(Transform interactorTransform){
        
        if(isInteracting == false){
            isInteracting = true;
            Debug.Log("Interact!");
            dialogue.SetActive(true);
            nameText.text = name;
            dialogueComponent = dialogue.GetComponent<Dialogue>();
            dialogueComponent.lines = dialogues;
            dialogueComponent.StartDialogue();
            if (dialogueComponent.done) {
                dialogueComponent.done = false;
            }
        } else{
            Debug.Log("Cannot Interact");
        }
            
    }

    public string getInteractText(){
        return InteractText;
    }

    public Transform GetTransform(){
        return transform;
    }
}

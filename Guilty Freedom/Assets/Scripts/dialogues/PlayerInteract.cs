using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            float interactRange = 4f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray){
                if(collider.TryGetComponent(out NPCInteractable npcInteractable)){
                    npcInteractable.Interact();
                }
            }
        }
        
    }

    public NPCInteractable GetInteractableObject(){
        List<NPCInteractable> npcInteractableList = new List<NPCInteractable>();
        float interactRange = 4f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray){
                if(collider.TryGetComponent(out NPCInteractable npcInteractable)){
                    npcInteractableList.Add(npcInteractable);
                }
            }

            NPCInteractable closestNPCInteractable = null;
            foreach(NPCInteractable npcInteractable in npcInteractableList){
                if(closestNPCInteractable == null){
                    closestNPCInteractable = npcInteractable;
                }else{
                    if(Vector3.Distance(transform.position, npcInteractable.transform.position) <
                       Vector3.Distance(transform.position, npcInteractable.transform.position)){
                        closestNPCInteractable = npcInteractable;
                    }
                }
            }

            return closestNPCInteractable;
        
    }
}

using UnityEngine;
using UnityEngine.Events;

namespace lee
{
    public class InteractableSystem : MonoBehaviour
    {
        [SerializeField, Header("對話資料")]
        private DialogueData dataDialogue;
        [SerializeField, Header("對話結束後事件")]
        private UnityEvent onDialogueFinish;
        [SerializeField, Header("啟動道具")]
        private GameObject propActive;
        [SerializeField, Header("啟動後對話資料")]
        private DialogueData dataDialogueActive;
        [SerializeField, Header("啟動後對話結束後事件")]
        private UnityEvent onDialogueFinishAfterActive;


        private string nameTarget = "PlayerCapsule";
        private DialogueSystem dialogueSystem;

        private void Awake() 
        {
            dialogueSystem = GameObject.Find("talk").GetComponent<DialogueSystem>();
        }
        
        private void OnTriggerEnter(Collider other) 
        {
            if(other.name.Contains(nameTarget))
            {
                if(propActive == null || propActive.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dataDialogue, onDialogueFinish);
                }
                else
                {
                    dialogueSystem.StartDialogue(dataDialogueActive, onDialogueFinishAfterActive);
                }
            }
        }

        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }
    } 
}


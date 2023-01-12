using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace lee
{
    public class DialogueSystem : MonoBehaviour
    {
        #region 資料區域
        [SerializeField, Header("對話間格"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;
        [SerializeField, Header("開頭對話")]
        private DialogueData dialogueOpening;
        [SerializeField, Header("對話案件")]
        private KeyCode dialogueKey = KeyCode.Space;

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);
        //prop(屬性欄)看不懂,LAMBDA=>也看不懂
        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContent;
        private GameObject goTriangle;
        private PlayerInput playerInput;
        #endregion
        private UnityEvent onDialogueFinish;
        #region 事件
        private void Awake() 
        {
            groupDialogue = GameObject.Find("talk").GetComponent<CanvasGroup>();
            textName = GameObject.Find("Talker").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("TalkSomething").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("TalkFinishIcon");
            goTriangle.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();

            StartDialogue(dialogueOpening);

        }    
        #endregion

        ///<summary>
        ///開始對話
        ///</summary>
        ///<param name = "data">對話資料</param>
        ///<param name = " _onDialogueFinish">對話結束後事件，可以空值</param>
        public void StartDialogue(DialogueData data, UnityEvent _onDialogueFinish = null)
        {
            playerInput.enabled = false;
            //啟動協程
            StartCoroutine(FadeGroup());
            StartCoroutine(TyperEffect(data));
            onDialogueFinish = _onDialogueFinish;
        }
        
        private IEnumerator FadeGroup(bool fadeIn = true)
        {
            //三源運算子 ?;
            //布林值 ? 1 : 10;
            //布林值為true,值等於1
            //布林值為false,值等於10
            float increase = fadeIn ?  0.1f : -0.1f;
            for(int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.04f);
            }
        }

        private IEnumerator TyperEffect(DialogueData data)
        {
            //取得名子
            textName.text = data.dialogueName;

            //迴圈對話段
            for(int j = 0; j < data.dialogueContents.Length; j++)
            {
                textContent.text = "";
                goTriangle.SetActive(false);
                //此段文字為所取得的對話段
                string dialogue = data.dialogueContents[j];

                //將取得對話段的文字,放入此物件文字內容
                //將此段文字以協程方式輸出
                for(int i = 0; i < dialogue.Length; i++)
                {
                    textContent.text += dialogue[i];
                    yield return dialogueIntervalTime;
                }
               
                goTriangle.SetActive(true);

                //還沒按下按鍵就等待
                while (!Input.GetKeyDown(dialogueKey))
                {
                    yield return null;
                }
            }
            
            StartCoroutine(FadeGroup(false));
            playerInput.enabled = true;
            onDialogueFinish?.Invoke();
        }
    }
}


using System.Collections;
using UnityEngine;

namespace lee
{
    ///<summary>
    ///協同程序Coroutine
    ///</summary>
    public class LearnCoroutine : MonoBehaviour
    {
        //條件有四個
        //using System.Collections
        //IEnumerator的方法
        //方法內 yield return(等待)
        //使用StartCoroutine(啟動)

        private string testDialogue = "阿阿阿阿阿";

        private void Awake() 
        {
            //StartCoroutine(Test());
            //Debug.Log(testDialogue[0]);
            //StartCoroutine(ShowDialogue());
            StartCoroutine(ShowDialogueUseFor());
        }

        #region Test
        private IEnumerator Test()
        {
            Debug.Log("First");
            yield return new WaitForSeconds(2);
            Debug.Log("Second");
            yield return new WaitForSeconds(3);
            Debug.Log("Third");
        }    
        #endregion

        #region ShowDialogue
        private IEnumerator ShowDialogue()
        {
            Debug.Log(testDialogue[0]);
            yield return new WaitForSeconds(0.1f);
            Debug.Log(testDialogue[1]);
            yield return new WaitForSeconds(0.1f);
            Debug.Log(testDialogue[2]);
        }    
        #endregion

        private IEnumerator ShowDialogueUseFor()
        {
           for(int i = 0; i < testDialogue.Length; i++)
           {
                Debug.Log(testDialogue[i]);
                yield return new WaitForSeconds(0.2f);
           }
        }       
    }
}


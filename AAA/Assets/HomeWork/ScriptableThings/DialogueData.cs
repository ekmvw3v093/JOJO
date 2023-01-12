using UnityEngine;

namespace lee
{
    ///<summary>
    ///腳本化物件(對話資料)
    ///</summary>
    [CreateAssetMenu(fileName = "New Dialogue Data", menuName = "DialogueData")]
    //腳本化物件所使用的名稱， 在unity介面上的類別
    public class DialogueData : ScriptableObject 
    {
        [Header("對話者名稱")]
        public string dialogueName;
        [Header("對話內容"), TextArea(2, 10)]
        //最小直列行數,文本區域在開始使用滾動條之前可以顯示的最大行數
        public string[] dialogueContents;
        
   
    }
}


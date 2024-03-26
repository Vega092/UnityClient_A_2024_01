using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STORYGAME
{
    [CreateAssetMenu(fileName = "NewStory" , menuName = "ScriptableObject/StoryTableObject")]
    public class StoryTableObject : ScriptableObject
    {
        public int storyNumber;         //스토리 번호
        public Enums.StoryType storyType;   //스토리 타입 설정
        public bool storyDone;

        [TextArea(10, 10)]
        public string storyText;
        public List<Option> options = new List<Option>();

        [System.Serializable]
        public class Option
        {
            public string optionText;
            public string buttonText;
            public EventCheck eventCheck;
        }

        [System.Serializable]
        public class EventCheck
        {
            public int checkValue;
            public Enums.EvenType eventType;
            public List<Result> successResult = new List<Result>();
            public List<Result> failResult = new List<Result>();
        }

        [System.Serializable]
        public class Result
        {
            public Enums.ResultType resultType; //스토리 타입 설정
            public int value;
            public Stats stats;
        }
    }
}

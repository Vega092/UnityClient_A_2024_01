using STORYGAME;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static STORYGAME.StoryTableObject;


[CreateAssetMenu(fileName = " New Story" , menuName = "ScriptableObjects/StoryModel")]
public class StoryModel : ScriptableObject
{
    public int storyNumber;                 //스토리 번호
    public Texture2D MainImage;       //스토리 보여줄 이미지 텍스쳐

    public enum STORYTYPE
    {
        MAIN,
        SUB,
        SERIAL
    }

    public STORYTYPE storytype;
    public bool storyDone;

    [TextArea(10, 10)]
    public string storyText;                    //메인 스토리

    public Option[] options;                    //선택지 배열

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
        public enum EventType : int
        {
            NINE,
            GoToBattle,
            CheckSTR,
            CheckDex,
            CheckCON,
            CheckINT,
            CheckWIS,
            CheckCHA
        }

        public EventCheck eventType;

        public Result[] successResult;
        public Result[] failedResult;
    }

    [System.Serializable]
    public class Result
    {
        public enum ResultType : int
        {
            ChangeHP,
            ChangeSP,
            AddExperince,
            GoToShop,
            GoToNextStory,
            GoToRandomStory,
            GoToEnding
        }

        public ResultType resultType;           //결과값 타입
        public int value;                                 //변화 수치 입력
        public Stats stats;                             //해당 스택 변화 수치
    }
}

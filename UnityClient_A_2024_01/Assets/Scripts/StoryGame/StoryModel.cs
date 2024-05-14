using STORYGAME;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static STORYGAME.StoryTableObject;


[CreateAssetMenu(fileName = " New Story" , menuName = "ScriptableObjects/StoryModel")]
public class StoryModel : ScriptableObject
{
    public int storyNumber;                 //���丮 ��ȣ
    public Texture2D MainImage;       //���丮 ������ �̹��� �ؽ���

    public enum STORYTYPE
    {
        MAIN,
        SUB,
        SERIAL
    }

    public STORYTYPE storytype;
    public bool storyDone;

    [TextArea(10, 10)]
    public string storyText;                    //���� ���丮

    public Option[] options;                    //������ �迭

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

        public ResultType resultType;           //����� Ÿ��
        public int value;                                 //��ȭ ��ġ �Է�
        public Stats stats;                             //�ش� ���� ��ȭ ��ġ
    }
}

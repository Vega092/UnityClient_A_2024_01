using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STORYGAME     //�̸� �浹 ����
{
    public class Enums              //������ Ÿ��
    {
        public enum StoryType           //���丮 Ÿ��
        {
            MAIN,
            SUB,
            SERIAL
        }

        public enum EvenType            //�̺�Ʈ �߻��� üũ
        {
            NONE,
            GoToBattle = 100,
            CheckSTR = 1000,
            CheckDEX,
            CheckCON,
            CheckINT,
            CheckWIS,
            CheckCHA
        }

        public enum ResultType          //�̺�Ʈ ��� ����
        {
            ChangeHp,
            ChangeSp,
            AddExperience,
            GoToShop,
            GoToNextStory,
            GoToRansdeomStory,
            GoToEnding
        }
    }

    [System.Serializable]
    public class Stats
    {
        public int hpPoint;
        public int spPoint;

        public int currentHpPoint;
        public int currentSpPoint;
        public int currentXpPoint;

        //�⺻ ���� ����
        public int strength;            //STR
        public int dexterity;           //DEX
        public int consitiution;       //CON
        public int intelligence;       //INT
        public int wisdom;             //WIS
        public int charisma;          //CHA
    }

}

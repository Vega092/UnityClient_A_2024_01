using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;                     //에디터
using System.Text;                   //텍스트 사용
using UnityEngine.UI;              //UI 사용하기 위해
using TMPro;


namespace STORYGAME        //이름 충돌 방지
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]

    public class GameSystemEditor : Editor                                          //유니티 에디터를 상속
    {
        public override void OnInspectorGUI()                                           //인스펙터 함수를 재정의
        {
            base.OnInspectorGUI();                                                              //기존 이스펙터를 가져와서 실행

            GameSystem gameSystem = (GameSystem)target;                 //게임 시스템 스크립트 타겟을 설정

            if (GUILayout.Button("Reset Story Models"))                             //버튼을 생성
            {
                gameSystem.ResetStoryModels();
            }

            if(GUILayout.Button("Assing Text Component By Name"))               //버튼을 생성 (UI 컴포넌트를 불러온다.)
            {
                //오브젝트 이름으로 Text 컴포넌트 찾기
                GameObject textobject = GameObject.Find("StoryTextUI");
                if (textobject != null)
                {
                    Text textComponent = textobject.GetComponent<Text>();
                    if (textComponent != null)
                    {
                        //Text component 할당
                        gameSystem.textComponent = textComponent;
                        Debug.Log("Text Componet assigned Successfully");
                    }
                }

            }
        }
    }
#endif
    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance;                   //간단한 싱글폰 화
        public Text textComponent = null;

        public float delay = 0.1f;                                      //각 글자가 나타나는 데 걸리는 시간
        public string fullText;                                           //전체 표시할 텍스트
        public string currentText = "";                              //현재까지 표시된 텍스트

        public enum GAMESTATE                                  //상태값 설정 열거형
        {
            STORYSHOW,
            WAITSELECT,
            STORYEND,
            ENDMODE
        }

        public GAMESTATE currentState;
        public StoryTableObject[] storyModels;                  //기존에 있던것 모델들 소스코드 위치 이동
        public StoryTableObject currentModels;                 //현재 스토리 모델 객체
        public int currentStroyIndex;                                   //스토리 모델 인덱스
        public bool showStory = false;
        private void Awake()
        {
            instance = this;
        }

        public void Start()                                         //게임 시작시
        {
            StartCoroutine(ShowText());                     //텍스트를 보여준다.
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) StoryShow(1);                  //Q 키를 누르면 1번 스토리
            if (Input.GetKeyDown(KeyCode.W)) StoryShow(2);                 //W 키를 누르면 2번 스토리
            if (Input.GetKeyDown(KeyCode.E)) StoryShow(3);                  //E 키를 누르면 3번 스토리

            if (Input.GetKeyDown(KeyCode.Space))
            {
                delay = 0.0f;
            }
        }

        public void StoryShow(int number)
        {
            if(!showStory)
            {
                currentModels = FindStoryModel(number);                         //스토리 모델을 번호로 찾아서
                delay = 0.1f;
                StartCoroutine(ShowText());                                                 //루틴을 실행 시킨다
            }
            
        }

        StoryTableObject FindStoryModel(int number)                     //스토리 모델 번호로 찾는 함수
        {
            StoryTableObject tempStoryModel = null;                         //temp 미리 저장 해놓은 변수를 선언
            for(int i = 0; i < storyModels.Length; i++)                          //버튼으로 받아온 리스트를 for문으로 검사하며
            {
                if (storyModels[i].storyNumber == number)                   //숫자가 같은 경우
                { 
                    tempStoryModel = storyModels[i];                            //밀리 선언해 놓은 변수에 넣고
                    break;                                                                      //for문을 빠져 나온다.
                }
            }

            return tempStoryModel;                                                  //스토리 모델을 돌려준다.
        }

        IEnumerator ShowText()
        {
            showStory = true;
            for (int i = 0; i < currentModels.storyText.Length; i++)
            {
                currentText = currentModels.storyText.Substring(0, i);
                textComponent.text = currentText;
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(delay);
            showStory = false;
        }


#if UNITY_EDITOR
        [ContextMenu("Reset Story Models")]

        public void ResetStoryModels()
        {
            storyModels = Resources.LoadAll<StoryTableObject>("");// Resources 폴더 아래 모든 StoryModel 불러오기
        }
#endif

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                       //UI를 컨트롤 할 것이라 추가
using System;                                   //String 관련 함수 사용하기 위해 추가

public class StorySystem : MonoBehaviour
{
    public static StorySystem instance;                 //간단한 싱글톤 화
    public StoryModel currentStoryModel;            //지금 스토리 모델 참조

    public enum TEXTSYSTEM
    {
        NONE,
        DOING,
        SELECT,
        DONE
    }

    public float delay = 0.1f;                                              //각 글자가 나타나는데 걸리는 시간
    public string fullText;                                                   //전체 표시할 텍스트
    private string currentText = "";                                    //현재까지 표시된 텍스트
    public Text textComponent;                                        //text 컴포넌트 UI
    public Text storyIndex;                                               //스토리 번호 표시할 UI
    public Image imageComponent;                                //이미지 UI

    public Button[] buttonWay = new Button[3];              //선택지 버튼 추가
    public Text[] buttonWayText = new Text[3];               //선택지 버튼 Text

    public TEXTSYSTEM currentTextShow = TEXTSYSTEM.NONE;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < buttonWay.Length; i++)
        {
            int wayIndex = i;
            buttonWay[i].onClick.AddListener(() => OnWayClick(wayIndex));
        }

        GoShowText();
    }

    public  void StoryModelinit()
    {
        fullText = currentStoryModel.storyText;
        storyIndex.text = currentStoryModel.storyNumber.ToString();

        for (int i = 0; i < currentStoryModel.options.Length; i++)
        {
            buttonWayText[i].text = currentStoryModel.options[i].buttonText;                        //버튼 이름을 설정
        }
    }

    public void OnWayClick(int index)
    {
        if (currentTextShow == TEXTSYSTEM.DOING)
            return;

        bool CheckEventTypeNone = false;            // 기본으로 None일때는 무조건 성공이라고 판단하고 실패시에 다시 불리는것을 피하기 위해서 bool 선언
        StoryModel playStoryModel = currentStoryModel;

        if (playStoryModel.options[index].eventCheck.eventType == StoryModel.EventCheck.EventType.NONE)
        {
            for(int i = 0; i < playStoryModel.options[index].eventCheck.successResult.Length; i++)
            {
                GameSystem.instance.ApplyChoice(currentStoryModel.options[index].eventCheck.successResult[i]);
                CheckEventTypeNone = true;
            }
        }
    }

    public void GoShowText()
    {
        StoryModelinit();
        ResetShow();
        StartCoroutine(ShowText());
    }

    public void ResetShow()
    {
        textComponent.text = "";

        for(int i = 0; i < buttonWay.Length; i++)
        {
            buttonWay[i].gameObject.SetActive(false);
        }
    }


    IEnumerator ShowText()                                                            //코루틴 함수 사용
    {
        currentTextShow = TEXTSYSTEM.DOING;

        if(currentStoryModel.MainImage != null)
        {
            //Texture2D를 Sprite 변환

            Rect recd = new Rect (0,0,currentStoryModel.MainImage.width , currentStoryModel.MainImage.height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);                    //스프라이트의 축(중심) 지정
            Sprite sprite = Sprite.Create(currentStoryModel.MainImage, recd, pivot);

            imageComponent.sprite = sprite; ;
        }
        else
        {
            Debug.Log("텍스쳐 로딩이 되지 않습니다. ; " + currentStoryModel.MainImage.name);
        }


        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);                                 //Substring 문자열 자르는 함수
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);                         //delay 초만큼 For 문을 지연 시킨다.
        }

        for (int i = 0; i < currentStoryModel.options.Length;i++)
        {
            buttonWay[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(delay);


        currentTextShow = TEXTSYSTEM.NONE;
    }

}

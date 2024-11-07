using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }

    public Image imgBG;
    public Image imgCharacter;
    public Text textName;
    public Text textTalkLine;
    public GameObject talkLineGo;//对话框父对象
    public Transform[] chacterPosTrans;
    public GameObject empChoiceUIGo;//选择对相框父对象
    public GameObject[] choiceUIGos;//用于储存显示的对相框
    public Text[] textChoiceUIs;

    private void Awake()
    {
        Instance = this;
    }

    //获取背景图片
    public void SetBGImageSprite(string spriteName)
    {
        imgBG.sprite = Resources.Load<Sprite>("Sprites/BG/"+spriteName);
    }

    //获取并更新人物立绘
    public void ShowCharacter(string name)
    {
        ShowOrHideTalkline();
        imgCharacter.sprite = Resources.Load<Sprite>("Sprites/Characters/" + name);
        imgCharacter.SetNativeSize();//将图片尺寸调整为原始尺寸
        imgCharacter.gameObject.SetActive(true);
        textName.text = name;

    }

    //更新文本显示
    public void UpdateTalkLineText(string dialogueContent)
    {
        textTalkLine.text = dialogueContent;
    }

    //更新人物位置
    public void SetCharacterPos(int posID, bool isRotate = false)
    {
        imgCharacter.transform.localPosition = chacterPosTrans[posID-1].localPosition;
        if (isRotate)
        {
            imgCharacter.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else 
        {
            imgCharacter.transform.eulerAngles = Vector3.zero;
        }
    }

    //暂时没用的number1的UI显示
    public void UpdateNumber1(int value = 0)
    {

    }

    //暂时没用的列表number2的UI显示
    public void UpdateNumber2(string name, int value)
    {

    }

    //显示选项对话框
    public void ShowChoiceUI(int choiceNum, string[] choiceContent)
    {
        empChoiceUIGo.SetActive(true);
        ShowOrHideTalkline(false);
        HideChoiceUI();
        for (int i = 0;i < choiceNum; i++)
        {
            choiceUIGos[i].SetActive(true);
            textChoiceUIs[i].text = choiceContent[i];
        }
    }

    //隐藏所有选项对话框
    public void HideChoiceUI() {
        for (int i = 0; i < choiceUIGos.Length; i++)
        {
            choiceUIGos[i].SetActive(false);
        }
    }

    //显示或隐藏对话框
    public void ShowOrHideTalkline(bool show = true)
    {
        talkLineGo.SetActive(show);
       
    }
}


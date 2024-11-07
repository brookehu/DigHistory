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
    public GameObject talkLineGo;//�Ի��򸸶���
    public Transform[] chacterPosTrans;
    public GameObject empChoiceUIGo;//ѡ�����򸸶���
    public GameObject[] choiceUIGos;//���ڴ�����ʾ�Ķ����
    public Text[] textChoiceUIs;

    private void Awake()
    {
        Instance = this;
    }

    //��ȡ����ͼƬ
    public void SetBGImageSprite(string spriteName)
    {
        imgBG.sprite = Resources.Load<Sprite>("Sprites/BG/"+spriteName);
    }

    //��ȡ��������������
    public void ShowCharacter(string name)
    {
        ShowOrHideTalkline();
        imgCharacter.sprite = Resources.Load<Sprite>("Sprites/Characters/" + name);
        imgCharacter.SetNativeSize();//��ͼƬ�ߴ����Ϊԭʼ�ߴ�
        imgCharacter.gameObject.SetActive(true);
        textName.text = name;

    }

    //�����ı���ʾ
    public void UpdateTalkLineText(string dialogueContent)
    {
        textTalkLine.text = dialogueContent;
    }

    //��������λ��
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

    //��ʱû�õ�number1��UI��ʾ
    public void UpdateNumber1(int value = 0)
    {

    }

    //��ʱû�õ��б�number2��UI��ʾ
    public void UpdateNumber2(string name, int value)
    {

    }

    //��ʾѡ��Ի���
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

    //��������ѡ��Ի���
    public void HideChoiceUI() {
        for (int i = 0; i < choiceUIGos.Length; i++)
        {
            choiceUIGos[i].SetActive(false);
        }
    }

    //��ʾ�����ضԻ���
    public void ShowOrHideTalkline(bool show = true)
    {
        talkLineGo.SetActive(show);
       
    }
}


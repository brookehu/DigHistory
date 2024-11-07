using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private List<ScriptData> scriptDatas;//�籾�б�
    private int scriptIndex;//�籾�б�����
    public int number1;//��ʱû�õĽ�ɫ��ֵ1
    public Dictionary<string, int> number2Dict;//��ʱû�õ�ÿ����ɫ����ҵ���ֵ2

    private void Awake()
    {
        Instance = this;
        scriptDatas = new List<ScriptData>
        {
            new ScriptData()
            {
                loadType = 1,spriteName="��¥",soundType = 3,soundPath = "����",
            },
            new ScriptData()
            {
                loadType = 2,name="�����",dialogueContent="���ģ��ǣ��ռ�ѽ�����������Ѷ���֮��",characterPos = 2,soundType = 1,soundPath = "01"
            },
             new ScriptData()
            {
                loadType = 2,name="�����",dialogueContent="˾��ܲ���ñظ������ء�",characterPos = 1,ifRotate=true,soundType = 1,soundPath = "02"
            },
            new ScriptData()
            {
                loadType = 2,name="�����",dialogueContent="Ѻ�����ݣ��ٻغ��С�",characterPos = 3,soundType = 1,soundPath = "03"
            },
            new ScriptData()
            {
                loadType = 2,name="������",dialogueContent="ة����ˣ����²��ã���ͤ��ʧ�����ս���δ����ס��ͤ��ʮ��κ���ѳ��Ʊƽ����Ҿ��������أ�ʿ�����䣬��ة���������ϣ�",characterPos = 1,soundType = 3,soundPath = "����"
            },
            new ScriptData()
            {
                loadType = 2,name="�����",dialogueContent="������ˣ��������ڶ�Ϊ���գ�ʿ������ǧ�࡭���������˴��⡭",characterPos = 3
            },
            new ScriptData()
            {
                loadType = 2,name="������",dialogueContent="ة����ˣ���ǰ����Σ�����о�ʮ�򣬶��ҷ�����ǧ�࣬�������⣡���硭�����������ǣ�������ս�ɣ�",characterPos = 1,ifRotate=true
            },
            new ScriptData()
            {
                loadType = 2,name="������",dialogueContent="�ɡ��ɳ��ж������޴����İ��հ��������������ܣ������а����ںεء�",characterPos = 2,ifRotate=true
            },
            new ScriptData()
            {
                loadType = 3,soundType = 3,soundPath = "����",eventData = 2,eventID = 1,
            },
            new ScriptData()
            {
                loadType = 3,name="�����",dialogueContent="���Ƕ���",characterPos = 2,eventData = 1,eventID = 2
            },
            new ScriptData()
            {
                loadType = 3,name="�����",dialogueContent="�س�",characterPos = 2,eventData = 2,eventID = 2
            },
            new ScriptData()
            {
                loadType = 1,spriteName="��ҵ��",scriptID = 1,soundType = 3,soundPath = "����",
            },
            new ScriptData()
            {
                loadType = 1,spriteName="����",
            },
            new ScriptData()
            {
                loadType = 1,spriteName="ũ��",
            },
            new ScriptData()
            {
                loadType = 1,spriteName="��¥"
            },
            new ScriptData()
            {
                loadType = 2,name="�����",dialogueContent="��������λ��ʿͬ�������������빲������֮�����������ҵ�չ��Ӣ�����ҳ�֮ʱ��������Ϊ�������Լ�������Ϊ��������ǧ������ա�",characterPos = 3,scriptID = 2,soundType = 3,soundPath = "ս��",
            },
            new ScriptData()
            {
                loadType = 2,name="�����",dialogueContent="����֮���գ����������ҵ�֮��ĸ���ҵ�֮���ӡ�Ψ�����Ӻ������һ���������ҵ������������Ȼ����ı�ڣ������˵У�",characterPos = 3
            },
            new ScriptData()
            {
                loadType = 2,name="������",dialogueContent="�ҵ�����׷��ة�࣡",characterPos = 2,ifRotate=true
            },
        };
        scriptIndex = 0;
        //�����������UI����
        HandleData();
        number1 = 111111;
        number2Dict = new Dictionary<string, int>()
        {
            {"Player",0 },
            {"�����",100 }
        };
        for (int i = 0; i < scriptDatas.Count; i++)
        {
            scriptDatas[i].scriptIndex = i;
        }
    }


    //�����������
    private void HandleData()
    {
        //����������ڵ��ھ����б����ֵ����Ϸ����
        if (scriptIndex >= scriptDatas.Count)
        {
            Debug.Log("Game Over");
            return;
        }
        //��ʼ��������
        PlaySound(scriptDatas[scriptIndex].soundType);
        if (scriptDatas[scriptIndex].loadType == 1)
        {
        
            //���ñ���ͼƬ
            SetBGImageSprite(scriptDatas[scriptIndex].spriteName);
            //������һ����������
            LoadNextScript();
        }
        else if(scriptDatas[scriptIndex].loadType == 2)
        {
            //������������
            HandleCharacter();
        }
        else if (scriptDatas[scriptIndex].loadType == 3)
        {
            //�����¼�
            switch (scriptDatas[scriptIndex].eventID) 
            { 
                //��ʾѡ����
                case 1:
                    ShowChoiceUI(scriptDatas[scriptIndex].eventData, GetChoiceConcent(scriptDatas[scriptIndex].eventData));
                    break;
                //��ת��ָ��λ��
                case 2:
                    SetScriptIndex();
                    Debug.Log("��ת����" + scriptIndex);
                    break;
                default: 
                    break;
            }
        }
        else
        {
            LoadNextScript();
        }
    }

    //���ر���ͼƬ
    private void SetBGImageSprite(string spriteName)
    {
        UIManager.Instance.SetBGImageSprite(spriteName);
    }

    //������һ����������
    public void LoadNextScript()
    {
        Debug.Log("������һ������" + scriptIndex);
        scriptIndex++;
        HandleData();
    }

    //��ʾ����
    private void ShowCharacter(string name)
    {
        UIManager.Instance.ShowCharacter(name);

    }

    //���¶Ի����ı�
    private void UpdateTalkLineText(string dialogueContent)
    {
        UIManager.Instance.HideChoiceUI();
        UIManager.Instance.UpdateTalkLineText(dialogueContent);
    }

    //��������λ��
    private void SetCharacterPos(int posID,bool isRotate = false)
    {
        UIManager.Instance.SetCharacterPos(posID,isRotate);

    }

    //���Ų�ͬ���͵�����
    public void PlaySound(int soundType)
    {
        switch (soundType)
        {
            case 1:
                AudioSourceManager.Instance.PlayDialogue(
                    scriptDatas[scriptIndex].name + "/" + scriptDatas[scriptIndex].soundPath);
                break;
            case 2:
                AudioSourceManager.Instance.PlaySound(
                    scriptDatas[scriptIndex].soundPath);
                break;
            case 3:
                AudioSourceManager.Instance.PlayMusic(
                    scriptDatas[scriptIndex].soundPath);
                break;


        }
    }

    //�޸�ĳ��ʱû�õı���number1
    public void ChangeNumber1(int value)
    {
        if (value == 0)
        {
            return;
        }
        if (value >= 1)
        {
            AudioSourceManager.Instance.PlaySound("��Ϸʤ����Ч");
        }

        number1 += value;

        if(number1 >= 100)
        {
            number1 = 100;
        }
        else if(number1 <= 0)
        {
            number1 = 0;
        }

    }

    //������ʱû�õ�number1��UI
    public void UpdateNumber1(int value = 0,string name = null)
    {
        UIManager.Instance.UpdateNumber1(value);
    }

    //�޸���ʱû�õ�number2
    public void ChangeNumber2(string name,int value)
    {
        if (value == 0)
        {
            return;
        }
        if (value >= 1)
        {
            AudioSourceManager.Instance.PlaySound("��Ϸʤ����Ч");
        }

        number2Dict[name] += value;

        if (number2Dict[name] >= 100)
        {
            number2Dict[name] = 100;
        }
        else if (number2Dict[name] <= 0)
        {
            number2Dict[name] = 0;
        }
    }

    //������ʱû�õ��б�number2��UI
    public void UpdateNumber2(string name,int value)
    {
        UIManager.Instance.UpdateNumber2(name,value);
    }
    
    //�����ɫ��ص�����
    public void HandleCharacter()
    {
        //��ʾ����
        ShowCharacter(scriptDatas[scriptIndex].name);
        //���¶Ի����ı�
        UpdateTalkLineText(scriptDatas[scriptIndex].dialogueContent);
        //��������λ��
        SetCharacterPos(scriptDatas[scriptIndex].characterPos, scriptDatas[scriptIndex].ifRotate);
        //����number1��number2[]
        ChangeNumber1(scriptDatas[scriptIndex].deltaNumber1);
        ChangeNumber2(scriptDatas[scriptIndex].name, scriptDatas[scriptIndex].deltaNumber2);

    }

    //��ʾѡ��Ի���
    public void ShowChoiceUI(int choiceNum, string[] ChoiceContent)
    {
        UIManager.Instance.ShowChoiceUI(choiceNum, ChoiceContent);
    }

    //��ȡѡ����Ϣ
    public string[] GetChoiceConcent(int num)
    {
        string[] choices = new string[num];
        for (int i = 0; i < num; i++)
        {
            choices[i] = scriptDatas[scriptIndex + 1 + i].dialogueContent;
        }
        return choices;
    }

    //��������Ϊָ����ֵ
    public void SetScriptIndex(int index = 0)
    {
        for (int i = 0; i < scriptDatas.Count; i++) 
        {
            if (scriptDatas[scriptIndex+index+1].eventData == scriptDatas[i].scriptID)
            {
                Debug.Log(scriptIndex);
                scriptIndex = scriptDatas[i].scriptIndex;
                break;
            }
        }
        HandleData();
        Debug.Log("ѡ��ɹ�" + scriptIndex);
    }
}




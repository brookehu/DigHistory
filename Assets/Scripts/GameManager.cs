using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private List<ScriptData> scriptDatas;//剧本列表
    private int scriptIndex;//剧本列表索引
    public int number1;//暂时没用的角色数值1
    public Dictionary<string, int> number2Dict;//暂时没用的每个角色对玩家的数值2

    private void Awake()
    {
        Instance = this;
        scriptDatas = new List<ScriptData>
        {
            new ScriptData()
            {
                loadType = 1,spriteName="城楼",soundType = 3,soundPath = "轻松",
            },
            new ScriptData()
            {
                loadType = 2,name="诸葛亮",dialogueContent="险哪！呵，险计呀！唉，不得已而用之！",characterPos = 2,soundType = 1,soundPath = "01"
            },
             new ScriptData()
            {
                loadType = 2,name="诸葛亮",dialogueContent="司马懿不久必复回西县。",characterPos = 1,ifRotate=true,soundType = 1,soundPath = "02"
            },
            new ScriptData()
            {
                loadType = 2,name="诸葛亮",dialogueContent="押运粮草，速回汉中。",characterPos = 3,soundType = 1,soundPath = "03"
            },
            new ScriptData()
            {
                loadType = 2,name="其他人",dialogueContent="丞相大人，大事不好！街亭已失，马谡将军未能守住街亭，十万魏军已趁势逼近。我军伤亡惨重，士气低落，请丞相速做决断！",characterPos = 1,soundType = 3,soundPath = "紧张"
            },
            new ScriptData()
            {
                loadType = 2,name="诸葛亮",dialogueContent="怎会如此？！如今城内多为百姓，士兵仅有千余…马稷怎会如此大意…",characterPos = 3
            },
            new ScriptData()
            {
                loadType = 2,name="其他人",dialogueContent="丞相大人，当前局势危急，敌军十万，而我方仅有千余，兵力悬殊！不如…不如我们弃城！来日再战吧！",characterPos = 1,ifRotate=true
            },
            new ScriptData()
            {
                loadType = 2,name="其他人",dialogueContent="可…可城中都是手无寸铁的百姓啊！我们弃城逃跑，至城中百姓于何地…",characterPos = 2,ifRotate=true
            },
            new ScriptData()
            {
                loadType = 3,soundType = 3,soundPath = "心跳",eventData = 2,eventID = 1,
            },
            new ScriptData()
            {
                loadType = 3,name="诸葛亮",dialogueContent="弃城而逃",characterPos = 2,eventData = 1,eventID = 2
            },
            new ScriptData()
            {
                loadType = 3,name="诸葛亮",dialogueContent="守城",characterPos = 2,eventData = 2,eventID = 2
            },
            new ScriptData()
            {
                loadType = 1,spriteName="商业街",scriptID = 1,soundType = 3,soundPath = "轻松",
            },
            new ScriptData()
            {
                loadType = 1,spriteName="房舍",
            },
            new ScriptData()
            {
                loadType = 1,spriteName="农田",
            },
            new ScriptData()
            {
                loadType = 1,spriteName="城楼"
            },
            new ScriptData()
            {
                loadType = 2,name="诸葛亮",dialogueContent="“我与诸位将士同生共死，荣辱与共。今日之困境，正是我等展现英勇与忠诚之时，不仅是为了我们自己，更是为了身后的万千黎民百姓。",characterPos = 3,scriptID = 2,soundType = 3,soundPath = "战斗",
            },
            new ScriptData()
            {
                loadType = 2,name="诸葛亮",dialogueContent="今日之百姓，便是他日我等之父母，我等之妻子…唯有听从号令，方有一线生机，我等虽兵力寡弱，然有智谋在，必能退敌！",characterPos = 3
            },
            new ScriptData()
            {
                loadType = 2,name="其他人",dialogueContent="我等誓死追随丞相！",characterPos = 2,ifRotate=true
            },
        };
        scriptIndex = 0;
        //人物相关数据UI更新
        HandleData();
        number1 = 111111;
        number2Dict = new Dictionary<string, int>()
        {
            {"Player",0 },
            {"诸葛亮",100 }
        };
        for (int i = 0; i < scriptDatas.Count; i++)
        {
            scriptDatas[i].scriptIndex = i;
        }
    }


    //处理剧情数据
    private void HandleData()
    {
        //如果索引大于等于剧情列表最大值，游戏结束
        if (scriptIndex >= scriptDatas.Count)
        {
            Debug.Log("Game Over");
            return;
        }
        //开始播放音乐
        PlaySound(scriptDatas[scriptIndex].soundType);
        if (scriptDatas[scriptIndex].loadType == 1)
        {
        
            //设置背景图片
            SetBGImageSprite(scriptDatas[scriptIndex].spriteName);
            //加载下一条剧情数据
            LoadNextScript();
        }
        else if(scriptDatas[scriptIndex].loadType == 2)
        {
            //加载人物立绘
            HandleCharacter();
        }
        else if (scriptDatas[scriptIndex].loadType == 3)
        {
            //加载事件
            switch (scriptDatas[scriptIndex].eventID) 
            { 
                //显示选择项
                case 1:
                    ShowChoiceUI(scriptDatas[scriptIndex].eventData, GetChoiceConcent(scriptDatas[scriptIndex].eventData));
                    break;
                //跳转到指定位置
                case 2:
                    SetScriptIndex();
                    Debug.Log("跳转结束" + scriptIndex);
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

    //加载背景图片
    private void SetBGImageSprite(string spriteName)
    {
        UIManager.Instance.SetBGImageSprite(spriteName);
    }

    //加载下一条剧情数据
    public void LoadNextScript()
    {
        Debug.Log("加载下一条剧情" + scriptIndex);
        scriptIndex++;
        HandleData();
    }

    //显示人物
    private void ShowCharacter(string name)
    {
        UIManager.Instance.ShowCharacter(name);

    }

    //更新对话框文本
    private void UpdateTalkLineText(string dialogueContent)
    {
        UIManager.Instance.HideChoiceUI();
        UIManager.Instance.UpdateTalkLineText(dialogueContent);
    }

    //更新人物位置
    private void SetCharacterPos(int posID,bool isRotate = false)
    {
        UIManager.Instance.SetCharacterPos(posID,isRotate);

    }

    //播放不同类型的音乐
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

    //修改某暂时没用的变量number1
    public void ChangeNumber1(int value)
    {
        if (value == 0)
        {
            return;
        }
        if (value >= 1)
        {
            AudioSourceManager.Instance.PlaySound("游戏胜利音效");
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

    //更新暂时没用的number1的UI
    public void UpdateNumber1(int value = 0,string name = null)
    {
        UIManager.Instance.UpdateNumber1(value);
    }

    //修改暂时没用的number2
    public void ChangeNumber2(string name,int value)
    {
        if (value == 0)
        {
            return;
        }
        if (value >= 1)
        {
            AudioSourceManager.Instance.PlaySound("游戏胜利音效");
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

    //更新暂时没用的列表number2的UI
    public void UpdateNumber2(string name,int value)
    {
        UIManager.Instance.UpdateNumber2(name,value);
    }
    
    //处理角色相关的内容
    public void HandleCharacter()
    {
        //显示人物
        ShowCharacter(scriptDatas[scriptIndex].name);
        //更新对话框文本
        UpdateTalkLineText(scriptDatas[scriptIndex].dialogueContent);
        //设置人物位置
        SetCharacterPos(scriptDatas[scriptIndex].characterPos, scriptDatas[scriptIndex].ifRotate);
        //更新number1和number2[]
        ChangeNumber1(scriptDatas[scriptIndex].deltaNumber1);
        ChangeNumber2(scriptDatas[scriptIndex].name, scriptDatas[scriptIndex].deltaNumber2);

    }

    //显示选项对话框
    public void ShowChoiceUI(int choiceNum, string[] ChoiceContent)
    {
        UIManager.Instance.ShowChoiceUI(choiceNum, ChoiceContent);
    }

    //获取选项信息
    public string[] GetChoiceConcent(int num)
    {
        string[] choices = new string[num];
        for (int i = 0; i < num; i++)
        {
            choices[i] = scriptDatas[scriptIndex + 1 + i].dialogueContent;
        }
        return choices;
    }

    //设置索引为指定数值
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
        Debug.Log("选择成功" + scriptIndex);
    }
}




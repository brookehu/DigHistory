using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//剧本数据
public class ScriptData
{
    public int loadType;//载入资源类型1、背景 2、人物 3、事件
    public string name;//角色名称
    public string spriteName;//图片资源路径
    public string dialogueContent;//对话内容
    public int characterPos;//立绘位置信息1、左  2、中  3、右
    public bool ifRotate;//翻转立绘（默认为false）
    public int soundType;//音频类型1、对话  2、音效  3、音乐
    public string soundPath;//音频路径
    public int deltaNumber1;//number1改变值
    public int deltaNumber2;//number2改变值
    public int eventID;//处理事件ID  1、显示选择项  2、跳转到指定位置
    public int eventData;//事件数据  1、选项数量
    public int scriptID;//用于跳转的标记位
    public int scriptIndex;//剧本索引的拷贝
}

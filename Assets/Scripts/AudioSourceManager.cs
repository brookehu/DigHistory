using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    public static AudioSourceManager Instance{ get; private set; }
    public AudioSource soundAudio;
    public AudioSource musicAudio;
    public AudioSource dialogueAudio;
    private void Awake()
    {
        Instance = this;
    }

    //��Ч������
    public void PlaySound(string soundPath)
    {
        soundAudio.PlayOneShot(Resources.Load<AudioClip>("SpritesAudioClips/Sound/" + soundPath));
    }

    //�������ֲ���
    public void PlayMusic(string musicPath,bool isLoop = true)
    {
        StopMusic();//����ͣ���֣����ԣ�
        musicAudio.loop = isLoop;//�Ƿ�ѭ������
        musicAudio.PlayOneShot(Resources.Load<AudioClip>("Sprites/AudioClips/Music/" + musicPath));
        musicAudio.Play();
    }

    //��ͣ��������
    public void StopMusic()
    { 
        musicAudio.Stop();
    }

    //��ɫ��������
    public void PlayDialogue(string dialoguePath)
    {
        dialogueAudio.Stop();
        dialogueAudio.PlayOneShot(Resources.Load<AudioClip>("Sprites/AudioClips/Dialogue/" + dialoguePath));
    }

    //��ͣ��ɫ����
    public void StopDialogue()
    {
        dialogueAudio.Stop();
    }
}

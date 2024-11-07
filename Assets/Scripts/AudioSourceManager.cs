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

    //Ãÿ–ß“Ù≤•∑≈
    public void PlaySound(string soundPath)
    {
        soundAudio.PlayOneShot(Resources.Load<AudioClip>("SpritesAudioClips/Sound/" + soundPath));
    }

    //±≥æ∞“Ù¿÷≤•∑≈
    public void PlayMusic(string musicPath,bool isLoop = true)
    {
        StopMusic();//œ»‘›Õ£“Ù¿÷£®≤‚ ‘£©
        musicAudio.loop = isLoop;// «∑Ò—≠ª∑≤•∑≈
        musicAudio.PlayOneShot(Resources.Load<AudioClip>("Sprites/AudioClips/Music/" + musicPath));
        musicAudio.Play();
    }

    //‘›Õ£±≥æ∞“Ù¿÷
    public void StopMusic()
    { 
        musicAudio.Stop();
    }

    //Ω«…´”Ô“Ù≤•∑≈
    public void PlayDialogue(string dialoguePath)
    {
        dialogueAudio.Stop();
        dialogueAudio.PlayOneShot(Resources.Load<AudioClip>("Sprites/AudioClips/Dialogue/" + dialoguePath));
    }

    //‘›Õ£Ω«…´”Ô“Ù
    public void StopDialogue()
    {
        dialogueAudio.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] private AudioSource itemAudio;//コンポーネント
    [SerializeField] private AudioClip sound;//BGM
public virtual void PickItem()
    {
        Debug.Log(this.ToString() + "を拾った");
        Play(sound, 1.0f);
        Destroy(this.gameObject);
    }
    private void Play(AudioClip audioClip, float volume)
    {
        itemAudio.clip = audioClip;
        itemAudio.volume = volume;
        itemAudio.Play();
    }
}

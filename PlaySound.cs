using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
  [SerializeField]
  public AudioClip soundEffect;
  [SerializeField]
  public AudioSource soundSource;
    // Start is called before the first frame update
    void PlayClip()
    {
        soundSource.Play();
    }

    // Update is called once per frame
    void Start()
    {
        //soundSource.clip = soundEffect;
    }
}

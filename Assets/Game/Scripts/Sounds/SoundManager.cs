using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SoundManager : MonoBehaviour
{
   public static SoundManager Instance;
   public AudioSource soundTrack;
   public AudioSource sfxBnts;
   public AudioSource sfxLineBingo;
   public AudioSource sfxWin;
   public AudioSource sfxLose;
   

   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
      DontDestroyOnLoad(gameObject);
   }
}

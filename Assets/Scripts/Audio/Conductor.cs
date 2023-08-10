using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class Conductor : MonoBehaviour
{
    public static Conductor Instance;

    public float songBpm;

    public float secPerBeat;

    public float songPos;

    public float songPosInBeats;

    public float dspSongTime;

    public AudioSource musicSource;

    [SerializeField]
    GameObject fullDmgSign, lessDmgSign;

    public bool lessDmgOn;
    public bool fullDmgOn;

    public float[] notes;
    int nextIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        secPerBeat = 60f / songBpm;

        dspSongTime = (float)AudioSettings.dspTime;
    }

    void Update()
    {
        songPos = (float)(AudioSettings.dspTime - dspSongTime);

        songPosInBeats = songPos / secPerBeat;

        DmgSign();

        if (nextIndex < notes.Length && notes[nextIndex] == Mathf.Round(songPosInBeats))
        {
            Debug.Log(Mathf.Round(songPosInBeats));
            lessDmgOn = false;
            fullDmgOn = true;
            nextIndex++;
        }
        //else if (nextIndex < notes.Length && notes[nextIndex] > Mathf.Round(songPosInBeats))
        //{
        //    Debug.Log(Mathf.Round(songPosInBeats));
        //    lessDmgOn = false;
        //    fullDmgOn = false;
        //    nextIndex++;
        //}
    }

    public void DmgSign()
    {
        if (!lessDmgOn && !fullDmgOn)
        {
            fullDmgSign.SetActive(false);
            lessDmgSign.SetActive(false);
        }
        else if (lessDmgOn && !fullDmgOn)
        {
            fullDmgSign.SetActive(false);
            lessDmgSign.SetActive(true);
        }
        else if (!lessDmgOn && fullDmgOn)
        {
            fullDmgSign.SetActive(true);
            lessDmgSign.SetActive(false);
        }
    }
}

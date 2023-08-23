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

    public float songLength;

    public AudioSource musicSource;

    [SerializeField]
    GameObject fullDmgSign, lessDmgSign;

    public bool lessDmgOn = false;
    public bool fullDmgOn = false;

    public float[] notes;
    int nextIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        secPerBeat = 60f / songBpm;

        //dspSongTime = (float)AudioSettings.dspTime;

        StartCoroutine(FullDmg());
    }

    void Update()
    {
        //songPos = (float)(AudioSettings.dspTime - dspSongTime);

        songPos += Time.deltaTime;

        songPosInBeats = songPos / secPerBeat;

        DmgSign();

        //if (nextIndex < notes.Length && notes[nextIndex] - 2.0 == Mathf.Round(songPosInBeats) - 2.0 && !lessDmgOn && !fullDmgOn)
        //{
        //    Debug.Log(Mathf.Round(songPosInBeats) - 2.0);
        //    lessDmgOn = true;
        //    fullDmgOn = false;
        //    //nextIndex++;
        //}
        //else if (nextIndex < notes.Length && notes[nextIndex] == Mathf.Round(songPosInBeats) && lessDmgOn && !fullDmgOn)
        //{
        //    Debug.Log(Mathf.Round(songPosInBeats));
        //    lessDmgOn = false;
        //    fullDmgOn = true;
        //    //nextIndex++;
        //}
        //else if (nextIndex < notes.Length && notes[nextIndex] + 1.5 == Mathf.Round(songPosInBeats) + 1.5 && !lessDmgOn && fullDmgOn)
        //{
        //    Debug.Log(Mathf.Round(songPosInBeats) + 1.5);
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

    private IEnumerator CheckNote()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (nextIndex < notes.Length && notes[nextIndex] - 0.5 == Mathf.Round(songPosInBeats) - 0.5 && !lessDmgOn && !fullDmgOn)
            {
                //Debug.Log(Mathf.Round(songPosInBeats) - 0.5);
                //lessDmgOn = true;
                //fullDmgOn = false;

                StartCoroutine(FullDmg());
            }
        }
    }

    private IEnumerator FullDmg()
    {
        //yield return new WaitForSeconds(0.5f);

        //Debug.Log(Mathf.Round(songPosInBeats));
        //lessDmgOn = false;
        //fullDmgOn = true;

        //StartCoroutine(NoDmg());

        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            fullDmgOn = true;

            StartCoroutine(NoDmg());
        }
    }

    private IEnumerator NoDmg()
    {
        yield return new WaitForSeconds(0.4f);

        //Debug.Log(Mathf.Round(songPosInBeats));
        //lessDmgOn = false;
        fullDmgOn = false;
        //nextIndex++;
    }
}

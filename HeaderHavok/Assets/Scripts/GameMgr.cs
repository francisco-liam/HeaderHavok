using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public AudioSource startSoundSource;
    public AudioClip startSoundClip;
    public float startSoundDuration;

    public AudioSource endSoundSource;
    public AudioClip endSoundClip;
    public float endSoundDuration;

    public GameObject startMenu;

    public bool running;

    public static GameMgr inst;

    public CannonController[] cannons;

    public void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        running = false;
        startSoundDuration = startSoundClip.length;
        endSoundDuration = endSoundClip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if(running == true && ScoreAndLivesMgr.livesCounter <= 0) 
        {
            running = false;
            StartCoroutine(EndGame());
        }   
    }

    public void StartButtonPressed()
    {
        StartCoroutine(StartGame());

    }

    IEnumerator StartGame()
    {
        ScoreAndLivesMgr.ResetLivesAndScore();
        startSoundSource.Play();
        startMenu.SetActive(false);
        yield return new WaitForSeconds(startSoundDuration);
        foreach (CannonController cannon in cannons)
        {
            cannon.shooting = true;
        }
        running = true;
    }

    IEnumerator EndGame()
    {
        foreach (CannonController cannon in cannons)
        {
            cannon.shooting = false;
        }
        endSoundSource.Play();
        yield return new WaitForSeconds(endSoundDuration + 3);
        startMenu.SetActive(true);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public AudioSource pointSound;
    public AudioSource damageSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Ball"))
        {
            ScoreAndLivesMgr.UpdateScore();
            pointSound.Play();
        }
        else if (collision.collider.tag.Equals("Object"))
            ScoreAndLivesMgr.UpdateLives();
            damageSound.Play();
    }
}

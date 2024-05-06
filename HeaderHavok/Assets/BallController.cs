using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public AudioSource hitSound;
    float timeSinceLastSound = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delete());
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSound += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(timeSinceLastSound >= .5)
            hitSound.Play();
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(10);
        Object.DestroyImmediate(this.gameObject);
    }
}

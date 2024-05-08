using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileController : MonoBehaviour
{
    public AudioSource projectileSound;
    bool deleting;

    // Start is called before the first frame update
    void Start()
    {
        deleting = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!deleting)
        {
            deleting = true;
            StartCoroutine(DeleteProjectile());
        }
        if(collision.collider.tag.Equals("Ground") || collision.collider.tag.Equals("MainCamera")) 
        {
            projectileSound.Play();
        }
    }

    IEnumerator DeleteProjectile()
    {
        yield return new WaitForSeconds(5);
        Object.Destroy(gameObject);
    }
}

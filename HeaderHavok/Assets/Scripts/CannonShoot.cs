using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour
{
    public GameObject[] cannonPrefabs;
    public Transform firePoint;
    public float shootForce = 10f;
    public float shootAngle = 45f;
    public float shootInterval = 8f;
    public AudioSource cannonSound;

    public bool shooting;
    private void Start()
    {
        shooting = false;
        StartCoroutine(ShootCannon());
    }

    IEnumerator ShootCannon()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            if(shooting)
            {
                GameObject cannonPrefab = cannonPrefabs[Random.Range(0, cannonPrefabs.Length)];

                GameObject cannon = Instantiate(cannonPrefab, firePoint.position, firePoint.rotation);

                Rigidbody cannonRigidbody = cannon.GetComponent<Rigidbody>();

                if (cannonRigidbody != null)
                {
                    Vector3 shootDirection = Quaternion.Euler(-shootAngle, 0, 0) * -firePoint.forward;
                    cannonRigidbody.AddForce(shootDirection * shootForce, ForceMode.Impulse);
                    cannonSound.Play();
                }
                else
                {
                    Debug.LogError("The cannon prefab doesn't have a Rigidbody component.");
                }
            }
        }
    }
}

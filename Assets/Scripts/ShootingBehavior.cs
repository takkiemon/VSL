using System.Collections;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward * .5f, Quaternion.identity);
            yield return new WaitForSeconds(2f); // Delay between shots
        }
    }
}

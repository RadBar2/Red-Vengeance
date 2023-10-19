using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    AudioSource audioSource;
    public bool player1 = true;

    [Header("Movement")]
    public float speed = 10;

    [Header("Shooting")]
    public GameObject Bullet;
    public float fireRate = 1;
    public Transform firePoint;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(Shoot), fireRate, fireRate);
    }

    void Update()
    {
        var direction = new Vector3();
        if(player1)
        { 
            direction.x = Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");
        }
        else
        {
            direction.x = Input.GetAxis("Horizontal2");
            direction.z = Input.GetAxis("Vertical2");
        }


        transform.position += direction * speed * Time.deltaTime;

        if(direction != Vector3.zero)
            transform.forward = direction;

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, firePoint.position, transform.rotation);
    }
}

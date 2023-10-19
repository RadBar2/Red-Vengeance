using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    AudioSource audioSource;
    public float speed = 20;
    public float lifetime = 3;
    // Update is called once per frame

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (audioSource != null)
        {
            audioSource.Play();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Gun gunPrefab;
    [SerializeField] private Spawn _zombieSpawn;
    [SerializeField] private AudioClip _sfx;
    private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        if (collision.gameObject.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.clip = _sfx;
                audioSource.Play();
            }
            if (gameObject.CompareTag("Gun"))
            {
                _zombieSpawn.StartWave();
            }
            Gun gun = Instantiate(gunPrefab, collision.gameObject.transform);
            gun.transform.position = collision.transform.position;
            gun.Equip();
            Destroy(gameObject, _sfx.length);
        }
        else
        {
            return;
        }
    }
}



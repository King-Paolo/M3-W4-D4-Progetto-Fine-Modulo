using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] AudioClip _sfx;
    [SerializeField] float _damage;
    private AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (audioSource == null) audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.clip = _sfx;
                audioSource.Play();
            }
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                LifeController zombie = enemy.GetComponent<LifeController>();
                if (zombie != null)
                {
                    zombie.TakeDamage(_damage);
                    ////Destroy(enemy);
                }
            }
            Debug.Log("Ottimo lavoro Frank, li abbiamo sterminati!");
            Destroy(gameObject, _sfx.length);
        }
    }
}

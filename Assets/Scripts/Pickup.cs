using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Gun gunPrefab;
    [SerializeField] private Spawn _zombieSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(gameObject.CompareTag("Gun"))
            {
                _zombieSpawn.StartWave();
            }
            Gun gun = Instantiate(gunPrefab, collision.gameObject.transform);
            gun.transform.position = collision.transform.position;
            gun.Equip();
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}



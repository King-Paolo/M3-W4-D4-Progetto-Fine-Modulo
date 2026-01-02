using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null)
                {
                    Destroy(enemy);
                    Destroy(gameObject);
                }
            }
            Debug.Log("Ottimo lavoro Frank, li abbiamo sterminati!");
        }
    }
}

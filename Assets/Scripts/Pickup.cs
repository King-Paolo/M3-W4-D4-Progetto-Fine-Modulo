using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Gun gunPrefab;
    public bool isEquipped;
    public bool IsEquipped { get { return isEquipped; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEquipped == true) return;
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isEquipped = true;
                Gun gun = Instantiate(gunPrefab, collision.gameObject.transform);
                gun.transform.position = collision.transform.position;
                Destroy(gameObject);
            }
        }
    }
}



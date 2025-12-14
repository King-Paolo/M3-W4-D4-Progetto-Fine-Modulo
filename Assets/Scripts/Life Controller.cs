using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] float hp;
    private void SetHp(float hp)
    {
        hp = Mathf.Max(0, hp);
        if (hp == 0)
        {
            Debug.Log(" Sei stato sconfitto!");
            Destroy(gameObject);
        }
        Debug.Log("Hp rimanenti" + hp);
    }
    public void TakeDamage(float damage) => SetHp(hp - damage);
}
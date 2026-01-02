using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Gun : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private float fireRange;
    [SerializeField] Bullet bulletPrefab;
    private float lastTimeShot;
    private bool isEquipped;
    private AnimationParamHandler _animParam;

    private void Awake()
    {
        _animParam = GetComponent<AnimationParamHandler>();
    }

    public GameObject FindNearestEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); // creo un array per cercare tutti i gameObject col tag "enemy" nella scena
        Vector2 player = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y); // posizione di partenza (quella del player) per calcolare la distanza dal nemico

        float distance;
        float minDistance = fireRange;
        GameObject NearestEnemy = null; // faccio un controllo per essere sicuro che il calcolo parta da 0

        foreach (GameObject enemy in enemys)
        {
            distance = Vector2.Distance(player, enemy.transform.position);
            if (distance < minDistance)
            {
                NearestEnemy = enemy;
                minDistance = distance;
            }
        }
        return NearestEnemy;
    }
    public void Shoot()
    {
        GameObject ClosestEnemy = FindNearestEnemy();
        if (ClosestEnemy != null)
        {
            Vector2 direction = ClosestEnemy.transform.position - gameObject.transform.position; // calcolo la direzione dei colpi
            direction.Normalize();
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.position = gameObject.transform.position;
            bullet.Set(direction); //dò il valore della direzione alla funzione
        }
    }
    public void Equip()
    {
        isEquipped = true;
    }
    private void Update()
    {
        if (Time.time - lastTimeShot > fireRate && isEquipped)
        {
            GameObject enemy = FindNearestEnemy();
            lastTimeShot = Time.time;
            Shoot();
            if(enemy != null) 
            {
                Vector2 direction = enemy.transform.position - transform.position;
                _animParam.SetHorizontalSpeedParam(direction.x);
            }
        }
    }
}

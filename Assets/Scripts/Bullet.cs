using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    private Vector2 direction;
    private Rigidbody2D rb;
    
    public void Set(Vector2 direction)
    {
        this.direction = direction;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Destroy(gameObject, 2f);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * (speed * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeController enemy = gameObject.AddComponent<LifeController>();
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.GetComponent<TilemapCollider2D>())
            Destroy(gameObject);
        if (enemy.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
        }
    }
}

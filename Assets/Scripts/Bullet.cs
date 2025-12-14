using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * (speed * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}

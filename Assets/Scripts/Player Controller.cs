using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    private float horizontal;
    private float vertical;
    Rigidbody2D rb;
    public Vector2 Direction { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);
        if (direction.sqrMagnitude >1)
            direction = direction.normalized;
        rb.MovePosition(rb.position + direction * (speed * Time.deltaTime));
    }
}

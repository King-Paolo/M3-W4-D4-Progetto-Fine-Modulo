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
    private AnimationParamHandler _animParam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animParam = GetComponent<AnimationParamHandler>();
        Debug.Log("Frank, questi zombie sono dappertutto, vai a prendere la pistola vicino alla mia auto, nel parcheggio");
    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);
        if (horizontal != 0 || vertical != 0)
        {
            _animParam.SetHorizontalSpeedParam(horizontal);
            _animParam.SetVerticalSpeedParam(vertical);
        }
        if (direction.sqrMagnitude > 1)
            direction = direction.normalized;
        rb.MovePosition(rb.position + direction * (speed * Time.deltaTime));
    }
}

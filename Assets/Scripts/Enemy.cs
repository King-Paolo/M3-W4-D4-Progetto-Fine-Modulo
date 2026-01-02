using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    private AnimationParamHandler _animParam;

    private void Awake()
    {
        _animParam = GetComponent<AnimationParamHandler>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeController player = collision.gameObject.GetComponent<LifeController>();
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        LifeController enemy = GetComponent<LifeController>();
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            if (enemy.Hp != 0)
            {
                gameObject.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

                Vector2 direction = player.transform.position - transform.position;
                _animParam.SetHorizontalSpeedParam(direction.x);
                _animParam.SetVerticalSpeedParam(direction.y);
            }
            else
            {
                gameObject.transform.position = transform.position;
            }
        }
        else
        {
            _animParam.SetHorizontalSpeedParam(0);
            _animParam.SetVerticalSpeedParam(0);
        }
    }
}

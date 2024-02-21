using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 startingPosition;

    private void Start()
    {
        transform.position = startingPosition;
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Net")
        {
            Controller.Score += 1;
            transform.position = startingPosition;
            rb.velocity = Vector3.zero;
        }
    }
}

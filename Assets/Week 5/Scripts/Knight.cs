using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    bool clickingOnSelf = false;
    public float health;
    public float maxHealth = 5;
    bool isDead = false;
    
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
    }
    private void FixedUpdate()
    {
       if(isDead) return;
        movement = destination - (Vector2)transform.position;
        if(movement.magnitude < 0.1) 
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !clickingOnSelf) 
        { 
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }

        animator.SetFloat("Movement", movement.magnitude);
    }
    private void OnMouseDown()
    {
        if (isDead) return;
            clickingOnSelf = true;
            SendMessage("TakeDamage", 1);
        
    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }


    public void TakeDamage(float damage) 
    {
        animator.SetTrigger("TakeDamage");
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if(health <= 0)
        {
            //die?
            animator.SetTrigger("Death");
            isDead = true;
        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");
        }
    }
}

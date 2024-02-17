using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RobotController : MonoBehaviour
{
    public float health;
    public float fullHealth = 10;
    public Animator animator;
    Vector3 moveTo;
    Rigidbody2D rb;
    public float speed = 5;
    public float shrinkdeath;
    public AnimationCurve deathCurve;
    public bool immovable = false;

    public UnityEngine.UI.Slider slider;
void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
        health = fullHealth;
        speed = 5;
        moveTo = transform.position ;
        slider.value = PlayerPrefs.GetFloat("robohealth");
        slider.value = health;
}

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            shrinkdeath = 2f * Time.deltaTime;
            float interpolation = deathCurve.Evaluate(shrinkdeath);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
            Debug.Log("Dead");
            immovable = true;
        }
        if (health > 0)
        {
            immovable = false;
            transform.localScale = Vector3.one;
        }
        if (immovable == true) return;
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            moveTo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveTo.y = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -5, -2);
            moveTo.z = transform.position.z;
        }
        // position = move from current position to vector3 moveTo, multiplied by float speed and deltatime
        
        transform.position = Vector3.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);

        

        if (moveTo != transform.position)
        {
            animator.SetBool("Moving", true);
        }
        if (moveTo == transform.position)
        {
            animator.SetBool("Moving", false);
        }
        
        
    }
    public void Damage(float Damage)
    {
        if (immovable == true) return;
        if (health > 0)
        {
            health -= 1;
            animator.SetTrigger("Damage");
            savetoslider();
        }
        

    }

    public void Emote()
    {
        if (immovable == true) return;
        animator.SetTrigger("Emote");
    }
    public void death()
    {
        health = 0;
        savetoslider();



    }
    public void heal()
    {
        health = fullHealth;
        savetoslider();


    }
    public void savetoslider()
    {
        slider.value = health;
        PlayerPrefs.SetFloat("robohealth", health);
    }
}

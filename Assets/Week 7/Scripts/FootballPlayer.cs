using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballPlayer : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float speed = 100;
    public float sizeMouse = 10.002f;
    public Color selectedColour = Color.yellow;
    public Color unselectedColour = new Color(130f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Selected(false);
    }
    private void OnMouseDown()
    {
        Controller.SetCurrentSelection(this);
    }
    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            sr.color = selectedColour;
        }
        else
        {
            sr.color = unselectedColour;
        }
    }
    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
    private void OnBecameInvisible()
    {
        transform.position = Vector3.zero;
    }
}



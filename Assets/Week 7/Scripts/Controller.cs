using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge;
    Vector2 direction;
    public static int Score;
    public TextMeshProUGUI ScoreUI;
    public static Controller ball;
    public static FootballPlayer CurrentSelection { get; private set; }

    private void Start()
    {
        if (ball == null )
        {
            ball = this;
        }
    }
    public static void SetCurrentSelection(FootballPlayer player)
    {
        if (CurrentSelection != null)
        {
            CurrentSelection.Selected(false);
        }
        CurrentSelection = player;
        CurrentSelection.Selected(true);
    }
    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            CurrentSelection.Move(direction);
            direction = Vector2.zero;
        }
    }
    private void Update()
    {
        if (CurrentSelection == null) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
            chargeSlider.value = charge;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)CurrentSelection.transform.position).normalized * charge;
        }

         ScoreUI.text = Score.ToString();

    }
}

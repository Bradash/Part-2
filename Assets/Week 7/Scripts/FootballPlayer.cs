using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballPlayer : MonoBehaviour
{
    SpriteRenderer sr;
    public float sizeMouse = 10.002f;
    public Color selectedColour = Color.yellow;
    public Color unselectedColour = new Color(130f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
}



using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballPlayer : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float sizeMouse = 10.002f;
    public Color selectedColor = Color.yellow;
    public Color unselectedColor = new Color(130f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        if (Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) < sizeMouse)
        {
            spriteRenderer.color = selectedColor;
        }
        if (Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) > sizeMouse)
        {
            spriteRenderer.color = unselectedColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position));

        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
    }
}

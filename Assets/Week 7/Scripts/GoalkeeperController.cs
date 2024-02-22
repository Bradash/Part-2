using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class GoalkeeperController : MonoBehaviour
{
    Vector3 goalPosition;
    Vector3 playerPosition;
    float keeperDistance;
    Vector3 keeperPosition;
    public Rigidbody2D rb;
    public float interpolation = 0.825f;

    void Start()
    {
        goalPosition = new Vector3(0f, 5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = Controller.CurrentSelection.transform.position;
        keeperDistance = Vector3.Distance(goalPosition, playerPosition);

        
        keeperPosition = Vector3.Lerp(goalPosition, playerPosition, interpolation);
        rb.transform.position = keeperPosition;
    }
}

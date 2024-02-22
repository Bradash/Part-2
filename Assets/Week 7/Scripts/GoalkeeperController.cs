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

    void Start()
    {
        goalPosition = new Vector3(0f, 5f, 0f);
        playerPosition = Controller.CurrentSelection.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        keeperDistance = Vector3.Distance(goalPosition, playerPosition);

        keeperPosition = goalPosition - playerPosition;
        rb.transform.position = keeperPosition;
    }
}

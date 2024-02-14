using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoverSceneTest : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public Transform startPosition;
    public Transform endPosition;
    public float lerpTimer;
    public float interpolation;
    public Color cola;
    public Color colb;
    public SpriteRenderer sr;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        interpolation = animationCurve.Evaluate(lerpTimer);
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, interpolation);
        lerpTimer = lerpTimer + Time.deltaTime;
        sr.color = Color.Lerp(cola, colb, interpolation);
    }

}

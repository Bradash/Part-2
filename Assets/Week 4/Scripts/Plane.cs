using System.Collections.Generic;
using UnityEngine;


public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed = 1;
    public AnimationCurve landing;
    float landingTimer;
    bool dangerZone;
    public SpriteRenderer spriteRenderer;
    public CircleCollider2D circleCollider;
    bool autoLanding;
    public int ScoreCount = 0;
    public PlaneSpawner PlaneSpawner;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        speed = Random.Range(1, 4);
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        autoLanding = false;
        PlaneSpawner.GetComponent<PlaneSpawner>();
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }


    void Update()
    {


        if (autoLanding == true)
        {
            landingTimer += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
                PlaneSpawner.ScoreCount += 1;
                Debug.Log(ScoreCount);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }

        }




    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spriteRenderer.color = Color.red;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            float dist = Vector3.Distance(currentPosition, collision.transform.position);
            if (dist < 0.1)
            {
                Destroy(gameObject);
            }

        }
        if (collision.tag == "Runway")
        {
            autoLanding = collision.OverlapPoint(transform.position);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spriteRenderer.color = Color.white;
        }

    }

    void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPostition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPostition);
    }

    void OnMouseDrag()
    {
        Vector2 newPostition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Vector2.Distance(lastPosition, newPostition) > newPointThreshold)
        {
            points.Add(newPostition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPostition);
            lastPosition = newPostition;
        }
    }
}

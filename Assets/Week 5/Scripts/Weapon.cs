using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Vector2 Spin;
    float Timer;
    public int MaxTime = 3;
    
    public float Speed = 1000;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 5;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision sends TakeDamage and destroy itself as a game object
        collision.gameObject.SendMessage("TakeDamage", 5, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
        
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > MaxTime)
        {
            Destroy(gameObject);
        }
        
    }
    private void FixedUpdate()
    {
        //Rotates locally
        transform.Rotate(Vector3.forward* -500.0f * Time.deltaTime);
        //Transform is Global as space is set to world
        transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);

        
    }

    
}

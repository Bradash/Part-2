
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public int ScoreCount = 0;
    public float spawnTime = 5.0f;
    private float timer = 0.0f;
    public GameObject[] PlanePrefab = new GameObject[4];
    Vector3 spawnPos;
    Quaternion spawnRot;
    // Start is called before the first frame update
    void Start()
    {
        //Position and Rotation of the Initial plane
        spawnPos.x = 0;
        spawnPos.y = 0;
        spawnPos.z = 0;
        spawnRot = Quaternion.Euler(0, 0, 0);
        //Forces a plane to spawn as soon as playmode is initiated starts
        timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer > spawnTime)
        {
            spawnTime += 5.0f;
            GameObject Plane = 
            Instantiate(PlanePrefab[Random.Range(0, 4)], spawnPos, spawnRot);
            Plane.GetComponent<Plane>().PlaneSpawner = this;
            //Changes the Position and Rotation of the plane as it instantiates
            spawnPos.x = Random.Range(-5, 5);
            spawnPos.y = Random.Range(-5, 5);
            spawnPos.z = 0;
            spawnRot = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }
    }
}

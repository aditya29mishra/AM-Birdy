using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pipe;
    public float timer;
    public float SpawnTime;

    public float offset;

    private bool isSpawn = true;

    void Start()
    {
        // Spawn();   
    }

    // Update is called once per frame
    void Update()
    {

        if (isSpawn)
        {
            if (timer < SpawnTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Spawn();
                timer = 0;
            }
        }
    }

    void Spawn()
    {

        float PositveOffset = transform.position.y + offset;
        float negativeOffset = transform.position.y - offset;

        Vector3 random = new Vector3(transform.position.x, Random.Range(negativeOffset, PositveOffset), 0);

        Instantiate(pipe, random, transform.rotation);
    }
    public void StopSpawning()
    {
        isSpawn = false;
    }
}

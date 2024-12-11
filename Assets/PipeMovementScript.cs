using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;

    public float deadZone;

    private bool isMoving = true; // Control flag

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

            if (transform.position.x < deadZone)
            {
                Destroy(gameObject);
            }
        }
    }
    public void StopMovement()
    {
        isMoving = false;
    }

}

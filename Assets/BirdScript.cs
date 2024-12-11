using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myRigidbody;
    public float flapStrength;

    public LogicScript logic;
    public AudioSource backgroundMusic;
    private bool canMove = true;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider2D)
    {
        Debug.Log($"Collide by: {collider2D.gameObject.name}");

        logic.gameOver();

    }
     public void DisableMovement()
    {
        canMove = false;
        myRigidbody.velocity = Vector2.zero; // Stop any ongoing movement
        myRigidbody.isKinematic = true; // Prevent further physics updates
    }

}

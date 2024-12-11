using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public LogicScript logic;
    void Start()
    {
      logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();   
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
    Debug.Log($"Triggered by: {other.gameObject.name}");
    logic.Score();
    }

}

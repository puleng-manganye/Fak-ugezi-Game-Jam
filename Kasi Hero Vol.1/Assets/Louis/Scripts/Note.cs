using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{ 
    private Rigidbody2D rigidBody;
    public float speed;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        rigidBody.velocity = new Vector2(0, -speed);
    }
}

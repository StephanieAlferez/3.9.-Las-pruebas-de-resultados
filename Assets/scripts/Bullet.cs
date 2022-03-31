using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D MyRb;
    public float Speed;
    private Vector2 Direction;
    
    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MyRb.velocity = (Direction * Speed);
        Destroy(gameObject, 5f);

    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

}

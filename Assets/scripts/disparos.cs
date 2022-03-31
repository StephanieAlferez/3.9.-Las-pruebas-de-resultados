using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparos : MonoBehaviour
{
    public Transform puntoDisparo;
    public GameObject Bullet;
    private float Horizontal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 direction;
            if (transform.localScale.x == 1.0f) direction = Vector2.right;
            else direction = Vector2.left;
            GameObject bullet = Instantiate(Bullet, transform.position + direction * 0.1f, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetDirection(direction);
        }
    }
}

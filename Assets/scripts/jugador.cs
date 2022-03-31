using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class jugador : MonoBehaviour
{
    public float vel = 5.0f;
    public float correrVel = 8.0f;
    public float fuerzaSalto = 600f;
    private float Horizontal;

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    public LayerMask capaSuelo;
    public Transform checkSuelo;

   
    bool enSuelo;
    bool CORRER;

    Rigidbody2D rb;
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    private void Awake()
    {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
    }

    private void Update()
    {

        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        float h;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            CORRER = true;
        }
        else
        {
            CORRER = false;
        }

        if (CORRER)
        {
            h = Input.GetAxis("Horizontal") * correrVel;
        }
        else
        {
            h = Input.GetAxis("Horizontal") * vel;

        }
        rb.velocity = new Vector2(h, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto);
            anim.SetTrigger("SALTAR");
        }

        if (h != 0)
        {
            anim.SetBool("CORRER", true);
        }
        else
        {
            anim.SetBool("CORRER", false);
        }


        anim.SetBool("enSuelo", enSuelo);

        coinsText.text = "Coins:" + numberOfCoins;
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapCircle(checkSuelo.position, 0.1f, capaSuelo);
    }

}


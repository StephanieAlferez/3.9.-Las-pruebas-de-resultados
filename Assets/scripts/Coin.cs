using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            jugador.numberOfCoins++;
            PlayerPrefs.SetInt("NumberOfCoins", jugador.numberOfCoins);
            Destroy(gameObject);
        }
    }
}

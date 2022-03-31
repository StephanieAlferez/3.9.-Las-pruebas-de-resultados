using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public GameObject Jugador;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Jugador.transform.position.x;
        transform.position = position;

    }
}

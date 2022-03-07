using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bola : MonoBehaviour
{
    public float velocidad = 30.0f;

    AudioSource fuenteDeAudio;

    public AudioClip audioGol, audioRaqueta, audioRebote;



    public int golesIzquierda = 0;
    public int golesDerecha = 0;

    public Text controladorIzquerda;
    public Text controladorDerecha; 

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;

        fuenteDeAudio = GetComponent<AudioSource>();

        controladorIzquerda.text = golesIzquierda.ToString();
        controladorDerecha.text = golesDerecha.ToString();
    }


    void OnCollisionEnter2D(Collision2D micolision) 
    {
        //Debug.Log(micolision.gameObject.name);
        if (micolision.gameObject.name == "raquetaIzquierda")
        {
            int x = 1;
            int y = direccionY(transform.position, micolision.transform.position);
            Vector2 direccion = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }else if (micolision.gameObject.name == "raquetaDerecha")
        {
            int x = -1;
            int y = direccionY(transform.position, micolision.transform.position);
            Vector2 direccion = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }
        
        if (micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo")
        {
            //Reproduzco el sonido del rebote
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();
        }

    }


    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta)
    {
        if (posicionBola.y > posicionRaqueta.y)
        {
            return 1;
        }
        else if (posicionBola.y < posicionRaqueta.y)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public void reiniciarBola(string direccion)
    {
        transform.position = Vector2.zero;
        velocidad = 30+((golesDerecha+golesIzquierda)*2);
        if (direccion =="Derecha")
        {
            //golesDerecha - 1;
            golesDerecha++;
            controladorDerecha.text = golesDerecha.ToString();
            GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
        }else if (direccion == "Izquierda")
        {
            //golesIzquierda - 1;
            golesIzquierda++;
            controladorIzquerda.text = golesIzquierda.ToString();
            GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
        }
        if (golesIzquierda==10 || golesDerecha==10) {
            SceneManager.LoadScene("Inicio");
        }
        fuenteDeAudio.clip = audioGol;
        fuenteDeAudio.Play();
    }
    void Update()
    {
        //Incremento la velocidad de la bola
        velocidad = velocidad + 0.01f;
    }
}

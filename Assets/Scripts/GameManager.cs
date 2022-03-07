using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    AudioSource fuenteDeAudio;
    public AudioClip audioInicio;
    
    void Start()
    {
        fuenteDeAudio = GetComponent<AudioSource>();
        fuenteDeAudio.clip = audioInicio;
        fuenteDeAudio.Play();
    }

    void Update()
    {
        //Si pulsa la tecla P o hace clic izquierdo empieza el juego
        if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButton(0))
        {
            //Cargo la escena de Juego
            // Nombre de la scene del juego, en mi caso es SampleScene
            fuenteDeAudio.Pause();
            SceneManager.LoadScene("SampleScene");
        }
    }
}
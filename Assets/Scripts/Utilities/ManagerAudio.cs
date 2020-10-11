using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAudio : MonoBehaviour{
    //para los recursos de sonido
    public AudioSource zona1Sound,zona2Sound,zona3Sound,menuSound,gameOverSound,buttonSound;
    //
    private GameManager gameManagerInstancia;
    //variable para poder comrpbar que musica poner
    public string nameBar;
    void Start(){
        gameManagerInstancia = FindObjectOfType<GameManager>();
        this.gameObject.name = nameBar;
        menuSong();
    }
    //cancion del primer nivel
    public void zone1Soung(){
        menuSound.Stop();
        zona2Sound.Stop();
        zona1Sound.Play();
        zona3Sound.Stop();
    }
    //metod para la musica del menu
    public void menuSong(){
        menuSound.Play();
        zona2Sound.Stop();
        zona1Sound.Stop();
        zona3Sound.Stop();
    }
    //este metodo reproduce el sonido
    public void pushButton(){
        buttonSound.Play();
    }

    //checamos contra que colliciona
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){

            if(this.gameObject.name == "zona2"){

                zona2Sound.Play();
                zona1Sound.Stop();
                zona3Sound.Stop();
                menuSound.Stop();
            }
            if(this.gameObject.name == "zona3"){

                zona3Sound.Play();
                zona1Sound.Stop();
                zona2Sound.Stop();
                menuSound.Stop();
            }
            if(this.gameObject.name == "final"){
                gameManagerInstancia.EndGame();
                gameOverSound.Play();
                zona2Sound.Stop();
                zona1Sound.Stop();
                zona3Sound.Stop();
                menuSound.Stop();
            }
        }
    }
    // Update is called once per frame
    void Update(){
        
    }
}

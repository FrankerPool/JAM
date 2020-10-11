using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerAudio : MonoBehaviour{
    //para los recursos de sonido
    public AudioSource zona1Sound,zona2Sound,zona3Sound,menuSound,gameOverSound,buttonSound;
    //
    private GameManager gameManagerInstancia;
    //variable para poder comrpbar que musica poner
    public string nameBar;
    public Image p10,p60,p100;
    void Start(){
        por10();
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

    public void por10(){
        p10.enabled = true;
        p60.enabled = false;
        p100.enabled = false;
    }

    public void por60(){
        p10.enabled = false;
        p60.enabled = true;
        p100.enabled = false;
    }

    public void por100(){
        p10.enabled = false;
        p60.enabled = false;
        p100.enabled = true;
    }

    //checamos contra que colliciona
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){

            if(this.gameObject.name == "zona2"){
                por60();
            }
            if(this.gameObject.name == "zona3"){
            }
            if(this.gameObject.name == "final"){
                por100();
                gameManagerInstancia.EndGame();
            }
        }
    }
    // Update is called once per frame
    void Update(){
        
    }
}

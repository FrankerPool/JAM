using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacule : MonoBehaviour{
    //contiene el nombre del obstaculo
    public string nameObstacule;
    //
    private PlayerController playerControllerInst;
    //al iniciar el juego se cambia el nombre del objeto
    void Start(){
        playerControllerInst = FindObjectOfType<PlayerController>();
        this.gameObject.name = nameObstacule;
        if(nameObstacule == "invisible"){
            ghostBox(4.0f);
        }
    }
    //se inicia la corrutina
    public void nerfObstacule(float extraSpeed, float timebuf,float velocityO){
        StartCoroutine(durationNerfObstacule(extraSpeed,timebuf,velocityO));
    }
    //se resta la velocidad indicada a la del jugador para despues de cierto tiempo sumarla
    IEnumerator durationNerfObstacule(float extraSpeed, float timebuf,float velocityO){
        playerControllerInst.removePoints();
        playerControllerInst.lessVelocity(velocityO,extraSpeed);
        yield return new WaitForSeconds(timebuf);
        playerControllerInst.changeVelocityLess(velocityO,extraSpeed);
    }
    //esto sirve para que cuando el jugador choque con algo se destruya este y al mismo tiempo sirve para que no se pase cualquier cosa
    void OnTriggerEnter2D(Collider2D other){
        if(nameObstacule == "obstacule" || nameObstacule == "invisible"){
            if(other.gameObject.tag == "Player"){
                destroyObject();
            }
        }
        if(other.gameObject.tag == "Player"){
            destroyObject();
        }
    }
    //en el segundo caso destruye el objeto al entrar en contacto en el primero al esperar certo tiempo
    public void destroyObject(){
        playerControllerInst.removePoints();
        this.GetComponent<SpriteRenderer>().enabled = false;
        // Destroy(this.gameObject);
    }
    //para activar de nuevo todos los objetos
    public void restarObject(){
        this.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void ghostBox(float efectTime){
        StartCoroutine(compGhostBox(efectTime));
    }

    IEnumerator compGhostBox(float timeEffect){
        this.gameObject.GetComponent<Collider2D>().enabled = true;
        this.gameObject.GetComponent<Animator>().SetBool("invisible",true);
        yield return new WaitForSeconds(timeEffect);
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<Animator>().SetBool("invisible",false);
    }

    //aqui lo que hago es comprobar que tipo de obstaculo es y en base a eso le defino un comportamiento
    void Update(){
        if(nameObstacule == "invisible"){
            ghostBox(4.0f);
        }
    }
}

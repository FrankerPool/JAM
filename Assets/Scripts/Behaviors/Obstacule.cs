using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacule : MonoBehaviour{
    //contiene el nombre del obstaculo
    public string nameObstacule;
    //al iniciar el juego se cambia el nombre del objeto
    void Start(){
        this.gameObject.name = nameObstacule;
    }
    //se inicia la corrutina
    public void nerfObstacule(int extraSpeed, float timebuf, Transform transformVeloci,int velocityO){
        StartCoroutine(durationNerfObstacule(extraSpeed,timebuf,transformVeloci,velocityO));
    }
    //se resta la velocidad indicada a la del jugador para despues de cierto tiempo sumarla
    IEnumerator durationNerfObstacule(int extraSpeed, float timebuf, Transform transformVeloci,int velocityO){
        transformVeloci.Translate (Vector3.up * 1 * (velocityO - extraSpeed) * Time.deltaTime);
        yield return new WaitForSeconds(timebuf);
        transformVeloci.Translate (Vector3.up * 1 * velocityO * Time.deltaTime);
    }
    //esto sirve para que cuando el jugador choque con algo se destruya este y al mismo tiempo sirve para que no se pase cualquier cosa
    void OnTriggerEnter2D(Collider2D other){
        if(nameObstacule == "obstacule" || nameObstacule == "invisible"){
            if(other.gameObject.tag == "Player"){
                destroyObject();
            }
        }
    }
    //en el segundo caso destruye el objeto al entrar en contacto en el primero al esperar certo tiempo
    public void destroyObject(){
        //Destroy(this.gameObject,1f);
        Destroy(this.gameObject);
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
            ghostBox(3.0f);
        }
    }
}

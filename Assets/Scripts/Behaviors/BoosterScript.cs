using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterScript : MonoBehaviour{
    //nombre del booster
    public string boosterName;
    //al iniciar cambiamos el nombre del obejto por el nombre del booster
    void Start(){
        this.gameObject.name = boosterName;
    }
    //este metodo se encarga de gestionar el booster para correr mas rapdido por cierto tiempo
    public void boosterVelocity(float extraSpeed, float timeBooster,Rigidbody2D transformVeloci,float velocityO){
        StartCoroutine(boosterTimerVel(extraSpeed,timeBooster,transformVeloci,velocityO));
    }
    //Este metodo se encarga de esperar algunos segundos para poder cambiar la velocidad por ese periodo de tiempo
    IEnumerator boosterTimerVel(float extraSpeed, float timeBooster, Rigidbody2D transformVeloci,float velocityO){
        transformVeloci.velocity = Vector2.up * (velocityO + extraSpeed);
        yield return new WaitForSeconds(timeBooster);
        transformVeloci.velocity = Vector2.up * (velocityO);
        print("cambio");
    }
    //Este metodo se encarga de ejecutar el metodo verdader el boostertimervel
    public void boosterInvisible(float timeBooster, GameObject player){
        StartCoroutine(boosterTimerInv(timeBooster,player));
    }
    //este metodo se encarga de desactivar el collider por un tiempo indefinddo
    IEnumerator boosterTimerInv(float timeBooster, GameObject player){
        player.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(timeBooster);
        player.GetComponent<Collider2D>().enabled = true;
    }
}
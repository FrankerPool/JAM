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
    public void boosterVelocity(int extraSpeed, float timeBooster,Transform transformVeloci,int velocityO){
        StartCoroutine(boosterTimerVel(extraSpeed,timeBooster,transformVeloci,velocityO));
    }
    //Este metodo se encarga de esperar algunos segundos para poder cambiar la velocidad por ese periodo de tiempo
    IEnumerator boosterTimerVel(int extraSpeed, float timeBooster, Transform transformVeloci,int velocityO){
        transformVeloci.Translate (Vector3.up * 1 * (velocityO + extraSpeed) * Time.deltaTime);
        yield return new WaitForSeconds(timeBooster);
        transformVeloci.Translate (Vector3.up * 1 * (velocityO) * Time.deltaTime);
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
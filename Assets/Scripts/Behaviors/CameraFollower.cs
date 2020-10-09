using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour{
    //el objeto que sera perseguido por la camara
    private GameObject follow;
    //la maximima y mina distancia de la pantalla en respecto a el nivel
    public Vector2 minCamaraPo,maxCamaraPo;
    public float smoonthTime = 0.15f;
    private Vector2 velocity;

    void Start(){
        follow = GameObject.FindGameObjectWithTag("Player");
    }
    //
    private void FixedUpdate() {
    float positionX = Mathf.SmoothDamp(transform.position.x,follow.transform.position.x, ref velocity.x,smoonthTime);
    float positionY = Mathf.SmoothDamp(transform.position.y,follow.transform.position.y, ref velocity.y,smoonthTime);
    transform.position = new Vector3(
        Mathf.Clamp(positionX,minCamaraPo.x,maxCamaraPo.x),
        Mathf.Clamp(positionY,minCamaraPo.y,maxCamaraPo.y),
        transform.position.z);
    }
}

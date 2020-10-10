using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour{
    //esta variable contiene la posicion del jugador
    private Transform playerTransform;
    public float offset;
    //este busca cada frame el bojetivo a seguir en este caso el que contenga el tag 'Player'
    private void Update() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start() {
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //se modifico por que aqui se veia un poco mal
    private void LateUpdate() {
        Vector3 temp = transform.position;
        temp.y = playerTransform.position.y;
        temp.y += offset;
        transform.position = temp;
    }
}

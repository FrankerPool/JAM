using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    //variable encargada de gestionar la velocidad del jugador
    public float speed = 0.1f;
    //instancia de gamemanager para acceder a los metodos
    private GameManager gameManagerInstancia;
    void Start(){
        gameManagerInstancia = FindObjectOfType<GameManager>();
    }

    //metod que gestiona el movimiento del jugador
    public void movPc(){
        if(gameManagerInstancia.currentGameState == GameState.inGame){
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            Vector2 movement = Vector2.zero;
            if(Input.GetKeyDown(KeyCode.A)){
                if(transform.position.x > -1.3f){
                    transform.position = new Vector2(transform.position.x - 1.3f, transform.position.y);
                }
            }

            if(Input.GetKeyDown(KeyCode.D)){
                if(transform.position.x < 1.3f){
                    transform.position = new Vector2(transform.position.x + 1.3f, transform.position.y);
                }
            }
        }
    }

    //aun estoy probando esto /*10/10/20*/
    public void movMovil(){
        if(gameManagerInstancia.currentGameState == GameState.inGame){
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began){
                if (touch.position.x < Screen.width / 2 && transform.position.x > -0.3f)
                    transform.position = new Vector2(transform.position.x - 1.75f, transform.position.y);
                if (touch.position.x > Screen.width / 2 && transform.position.x < 0.3f)
                    transform.position = new Vector2(transform.position.x + 1.75f, transform.position.y);
            }
        }
    }

    // Update is called once per frame
    void Update(){
        movPc();
    }
}

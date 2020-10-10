using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour{
    // Start is called before the first frame update
    void Update(){
        StartCoroutine(intro());
    }
    //al iniciar el juego mostrara el logo y despues de 2 segundos cargara el menu
    IEnumerator intro(){
        yield return new WaitForSeconds(2);
        Loader.load(Loader.Scene.Principal);
    }
}

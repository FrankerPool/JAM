using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour{
    //definimos una accion para ejecutar el metodo
public enum Scene{
        Loading,Principal
}
    private static Action onLoaderCallBack;
    //encuanto la ecena este cargada al 100 cambia
    public static void load(Scene scene){
        onLoaderCallBack =() =>{
            SceneManager.LoadScene(scene.ToString());
        };
        SceneManager.LoadScene(Scene.Loading.ToString());
    }
    //en caso de no cumplirse vuelve a cargar la ecena
    public static void LoaderCallBack(){
        if(onLoaderCallBack!=null){
            new WaitForSeconds(3);
            onLoaderCallBack();
            onLoaderCallBack = null;
        }
    }
}

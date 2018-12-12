using UnityEngine;
using System.Collections;

//agregamos nuevos using para poder usar el New GUI
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextoParpadeante : MonoBehaviour
{
    public Text textoParpadeante;
    //Agregamos las variables de Texto y Strings
  
    string textoQueParpadea = "Press Start";
    string textoEnBlanco = "";
    string textoEstatico = "Press Start";

    //Agregamos una bandera que sera nuestro identificador para cambiar el texto
    bool estaParpadeando = true;

    void Start()
    {
        //obtenemos el componente del texto
        textoParpadeante = GetComponent<Text>();

        //llamamos al coroutine de la funcion de TextoParpadeo
        StartCoroutine(TextoParpadeo());

        //llamamos a la otra funcion para saber si se detuvo el tiempo de parpadeo
        StartCoroutine(DetenerParpadeo());
    }

    //funcion para que parpadee el texto
    public IEnumerator TextoParpadeo()
    {
        //el parpadeo sera infinito hasta que termine la condicion dependiendo tu eleccion
        while (estaParpadeando)
        {
            //Establecemos nuestro texto en blanco
            textoParpadeante.text = textoEnBlanco;

            //mostramos el texto en blanco por 0.5 segundos
            yield return new WaitForSeconds(.5f);

            //mostramos nuestro texto en mi caso Depredador1220 por otros 0.5 segundos
            textoParpadeante.text = textoQueParpadea;
            yield return new WaitForSeconds(.5f);
        }
    }

    //funcion para detener el parpadeo
    public IEnumerator DetenerParpadeo()
    {
        //Esperamos por 5 segundos
        yield return new WaitForSeconds(20f);

        //detenemos el parpadeo
        estaParpadeando = false;

        //mostramos diferentes textos para probar
        textoParpadeante.text = textoEstatico;
    }
}
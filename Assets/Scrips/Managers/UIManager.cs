using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public  Image barraVida;
    public  Animator salud;
    public  Animator efectoDePantalla;
    

    public  Animator cargador;



    private void Awake()
    {
        Instance = this;
    }
   
    public static void ActualizarVida(float vidaActual, float vidaMaxima)
    {
        float porcentaje = vidaActual / vidaMaxima;
        Instance.barraVida.fillAmount = porcentaje;
        Instance.salud.SetFloat("vidaActual", vidaActual);

    }

}

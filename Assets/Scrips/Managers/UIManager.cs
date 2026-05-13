using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image barraVida;
    public Animator cargador;
    public Animator salud;


    public void ActualizarVida(float porcentaje)
    {
        barraVida.fillAmount = porcentaje;
    }

}

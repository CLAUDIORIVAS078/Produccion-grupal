using UnityEngine;

public abstract class Balas: MonoBehaviour
{
    [SerializeField]
    protected float _velocidad;
    [SerializeField]
    protected float _daño;
    [SerializeField]
    protected float _vida;
    protected Transform _transBala;

    public abstract void Desaparece();
    protected abstract void OnBecameVisible();
}

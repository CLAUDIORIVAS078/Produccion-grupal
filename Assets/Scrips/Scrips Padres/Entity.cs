using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected int _vidaMax;
    [SerializeField]
    protected int _daño;
    [SerializeField]
    protected int _vision;
    [SerializeField]
    protected float _velocidad;
    [SerializeField]
    protected float _dashForce;
    [SerializeField]
    protected int _vidaActual;

    [SerializeField]
    protected Rigidbody2D _rb;
    [SerializeField]
    protected Animator _animator;
    [SerializeField]
    protected Transform _meTrans;

    public abstract void DañoRecivido(int dañoRes);

    public abstract void Muerto();
    
}
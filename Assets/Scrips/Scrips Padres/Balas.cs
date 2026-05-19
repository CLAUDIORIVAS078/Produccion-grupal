using UnityEngine;

public abstract class Balas: MonoBehaviour
{
    [SerializeField]
    protected float _velocidad;
    [SerializeField]
    protected int _daño;
    [SerializeField]
    protected float _vida;
    protected Transform _transBala;

    public static Balas instance;

    private void Start()
    {
        _transBala = GetComponent<Transform>();
    }

    private void Update()
    {
        _transBala.position += transform.right * _velocidad * Time.deltaTime;
        Desaparece();
    }

    public abstract void Daño(int dmg);
    public abstract void Desaparece();
    protected abstract void OnBecameVisible();
}

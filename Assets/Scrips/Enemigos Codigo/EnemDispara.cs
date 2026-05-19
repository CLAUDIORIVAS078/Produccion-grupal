using UnityEngine;

public class EnemDispara : Enemigos
{
    [Header("Variables")]
    [SerializeField]
    private float _velDisparo;
    private float _contador;

    [Header("GameObject de disparo")]
    [SerializeField]
    private GameObject _bala;
    [SerializeField]
    private GameObject _spownBala;
    private Vector2 _dirBala;
    private RaycastHit2D _hit;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _vidaActual = _vidaMax;
    }

    private void Update()
    {
        _dirBala = _player.transform.position - _spownBala.transform.position;
        _spownBala.transform.right = _dirBala;
        _hit = Physics2D.Raycast(_spownBala.transform.position, _dirBala, _rangoVision);
        if (_hit.collider == null)  { Debug.Log("Manco te falto colider"); }
        else if (_hit.transform.gameObject.layer == 7) { Comportamiento(); } 
    }

    private void Comportamiento() //Pasar a una FMS para mejorar el comportamiento
    {
        Debug.Log(_hit.transform.name);
        if (_dirBala.magnitude <= _rangoAccion) { Correr(); }
        else if (_dirBala.magnitude <= _rangoVision) { Disparo(); }
    }    

    private void Correr()
    {
        var dri = _player.transform.position - transform.position;
        dri = dri.normalized;
        _rb.linearVelocity= -dri * _velocidad;
    }

    private void Disparo()
    {
        _rb.linearVelocity = Vector2.zero;
        if (_contador >= _velDisparo)
        {
            Instantiate(_bala, _spownBala.transform.position, _spownBala.transform.rotation);
            BalaEnem.instance.Daño(_daño);
            _contador = 0;
        }
        else { _contador++; }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _rangoVision);
        Gizmos.DrawWireSphere(transform.position, _rangoAccion);
        if (_dirBala.magnitude <= _rangoVision) { Gizmos.color = Color.yellow; }
        else {  Gizmos.color = Color.green; }
        Gizmos.DrawLine(transform.position, _player.transform.position);
    }
    public override void DañoRecivido(int dañoRes)
    {
        _vidaActual -= dañoRes;
        if(_vidaActual <= 0) { Muerto(); }
    }

    public override void Muerto()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [Header("Variables Player")]
    [SerializeField]
    private float _radio;
    [SerializeField]
    private float _angulo;
    [SerializeField]
    private float _rango;
    [SerializeField]
    private float _cantBalas;
    [SerializeField]
    private float _tempRecarga;
    [SerializeField]
    private float _maxAmmo;
    [SerializeField]
    private float _fireRate;

    private float _cdDisparo;

    [Header("Codigos Personajes")]
    private PlaMovimiento _plamoviento;
    private PleControls _pleControls;
    private Player _player;
    [SerializeField]
    private Animator _hijoAnimator;

    private bool _recargando = false;

    [Header("Game Objects")]
    [SerializeField]
    private GameObject _bala;
    [SerializeField]
    private Transform _rotSpownPoint;
    [SerializeField]
    private Transform _spownPoint;
    [SerializeField]
    private Transform _mouse;




    private void Start()
    {
        _player = GetComponent<Player>();
        _rb = GetComponent<Rigidbody2D>();
        _meTrans = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _plamoviento = new PlaMovimiento(_rb, _velocidad, _rotSpownPoint, transform, _spownPoint, _angulo, _animator);
        _pleControls = new PleControls(_plamoviento, _player, _dashForce, _mouse);
        _vidaActual = _vidaMax;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _pleControls.ArtificialUpdate();
    }

    public override void DañoRecivido(int dañoRes)
    {    
        _vidaActual-= dañoRes;
        UIManager.ActualizarVida(_vidaActual, _vidaMax);
        UIManager.Instance.efectoDePantalla.SetTrigger("Dañado");
        //Object.FindAnyObjectByType<UIManager>().salud.SetFloat("vidaActual", _vidaActual);
        if (_vidaActual <= 0) { Muerto(); }
    }

    public override void Muerto()
    {
        Destroy(gameObject);
    }


    public void Disparo()
    {
        if (_cantBalas > 0)
        {
            if (_cdDisparo >= _fireRate)
            {
                _cantBalas--;
                _cdDisparo = 0;
                //Object.FindAnyObjectByType<UIManager>().cargador.SetTrigger("Disparar");
                SoundManager.instance.PlaySFX(SoundManager.instance.disperoPlayer);
                StartCoroutine(AniArma());
            }
            else { _cdDisparo++; }
        }
        else { }
    }

    IEnumerator AniArma()
    {
        _hijoAnimator.SetBool("Disparo", true);
        Instantiate(_bala, _spownPoint.position, _rotSpownPoint.rotation);
        BalaPlayer.instance.Daño(_daño);
        UIManager.Instance.cargador.SetTrigger("Disparar");
        yield return new WaitForSeconds(0.1f);
        _hijoAnimator.SetBool("Disparo", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(transform.position.x + _radio, transform.position.y + _radio, transform.position.z), new Vector3(transform.position.x + _radio, transform.position.y - _radio, transform.position.z));
        Gizmos.DrawLine(new Vector3(transform.position.x + _radio, transform.position.y - _radio, transform.position.z), new Vector3(transform.position.x - _radio, transform.position.y - _radio, transform.position.z));
        Gizmos.DrawLine(new Vector3(transform.position.x - _radio, transform.position.y - _radio, transform.position.z), new Vector3(transform.position.x - _radio, transform.position.y + _radio, transform.position.z));
        Gizmos.DrawLine(new Vector3(transform.position.x - _radio, transform.position.y + _radio, transform.position.z), new Vector3(transform.position.x + _radio, transform.position.y + _radio, transform.position.z));
        //if (_angulo <= 0) { return; }
        //float medioAngulo = _angulo * 0.5f;
        //Vector2 p1 = PointForAngle(medioAngulo, _rango);
        //Vector2 p2 = new Vector2(p1.x, -p1.y);
        //Vector2 p3 = new Vector2(-p1.x, p1.y);
        //Vector2 p4 = new Vector2(-p1.x, -p1.y);
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, (Vector2)transform.position + p1);
        //Gizmos.color = Color.gray;
        //Gizmos.DrawLine(transform.position, (Vector2)transform.position + p2);
        //Gizmos.DrawLine(transform.position, (Vector2)transform.position + p3);
        //Gizmos.DrawLine(transform.position, (Vector2)transform.position + p4);
        var _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawWireSphere(_mousePosition, _rango);
    }

    public void CamaraControl(Transform cursor)
    {
        var vecCurPle = cursor.position - transform.position;
        var camPos = vecCurPle / 2f;
        //if (camPos.magnitude >= 2.5f)
        //{
        //    Camera.main.transform.position = new Vector3(camPos.x, camPos.y, Camera.main.transform.position.z);
        //}
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    public void Recarga()
    {
        if(_cantBalas >= _maxAmmo)
        {
            _cantBalas = _maxAmmo;
            return;
        }
        if(!_recargando) { StartCoroutine(Recargando()); }
    }

    private IEnumerator Recargando()
    {
        _recargando = true;
        SoundManager.instance.PlaySFX(SoundManager.instance.recarga);
        UIManager.Instance.cargador.SetTrigger("Recargar");
        yield return new WaitForSeconds(_tempRecarga);
        _cantBalas = _maxAmmo;
        _recargando = false;
    }

    Vector3 PointForAngle(float angulo, float distancia)
    {
        return new Vector2 (Mathf.Cos(_angulo * Mathf.Deg2Rad), Mathf.Sin(_angulo * Mathf.Deg2Rad)) * distancia;
    }
}

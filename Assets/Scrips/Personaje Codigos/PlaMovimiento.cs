using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class PlaMovimiento
{
    private float _angulo;
    private float _vel;
    private Rigidbody2D _rb;
    private Transform _brazoTrans;
    private Transform _pleTrans;
    private Transform _spownBala;
    private Animator _animator;
    
    public PlaMovimiento(Rigidbody2D rb2D, float velocidad, Transform brazoTrans, Transform pleTrans, Transform spownBala,float angulo, Animator ani) 
    {
        _rb = rb2D;
        _brazoTrans = brazoTrans;
        _vel = velocidad;
        _pleTrans = pleTrans;
        _spownBala = spownBala;
        _angulo = angulo;
        _animator = ani;
    }

    public void Movimiento(Vector2 direction)
    {
        if (direction != Vector2.zero) 
        { 
            _rb.linearVelocity = direction * _vel;
            _animator.SetBool("Me Muevo", true);
        }
        else
        {
            _rb.linearVelocity = Vector2.zero;
            _animator.SetBool("Me Muevo", false);
        }
    }

    public void Rotacion(Transform dirMirar)
    {
        var vecApuntado = dirMirar.position - _spownBala.position;
        _brazoTrans.right = new Vector3(vecApuntado.x, vecApuntado.y, 0);
        if (dirMirar.position.x > _pleTrans.position.x)
        {
            _animator.SetBool("Camina Derecha", true);
            _animator.SetBool("Camina Izquierda", false);
        }
        else
        {
            _animator.SetBool("Camina Derecha", false);
            _animator.SetBool("Camina Izquierda", true);
        }
        //Vector2 p1, p2, p3, p4;
        //p1 = PointForAngle(_angulo);
        //p2 = new Vector2(p1.x, -p1.y);
        //p3 = new Vector2(-p1.x, p1.y);
        //p4 = new Vector2(p1.x, -p1.y);
        //Vector2 playVec = dirMirar.position - _pleTrans.position;
        //if (Vector3.Angle(playVec.normalized, _pleTrans.right) < Vector3.Angle(p1, _pleTrans.right)) { Debug.Log("Z1 Fue"); }
        //else if (Vector3.Angle(playVec.normalized, _pleTrans.right) < Vector3.Angle(p3, _pleTrans.right) && dirMirar.position.y > _pleTrans.position.y) 
        //{ Debug.Log("Z2 Fue"); }
        //else if (Vector3.Angle(playVec.normalized, _pleTrans.right) < Vector3.Angle(p3, _pleTrans.right) && dirMirar.position.y < _pleTrans.position.y) 
        //{ Debug.Log("Z4 Fue"); }
        //else { Debug.Log("Z3 Fue"); }
    }

    Vector3 PointForAngle(float angulo)
    {
        return new Vector2(Mathf.Cos(_angulo * Mathf.Deg2Rad), Mathf.Sin(_angulo * Mathf.Deg2Rad));
    }

    public void Dash(float dashForce) { _rb.AddForce(_brazoTrans.right.normalized * dashForce, ForceMode2D.Impulse); }

}
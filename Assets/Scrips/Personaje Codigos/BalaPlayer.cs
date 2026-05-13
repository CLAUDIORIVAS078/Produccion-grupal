using UnityEngine;

public class BalaPlayer : Balas
{

    private void Start()
    {
        _transBala = GetComponent<Transform>();
    }

    private void Update()
    {
        _transBala.position += transform.right * _velocidad * Time.deltaTime;
        Desaparece();
    }

    public override void Desaparece()
    {
        if(_vida <= 0) { Destroy(gameObject); }
        else { _vida -= Time.deltaTime; }
    }

    protected override void OnBecameVisible()
    {
         
    }
}

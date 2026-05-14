using UnityEngine;

public class BalaPlayer : Balas
{
    private void Awake()
    {
        instance = this;
    }
    public override void Desaparece()
    {
        if(_vida <= 0) { Destroy(gameObject); }
        else { _vida -= Time.deltaTime; }
    }
    public override void Daño(int dmg)
    {
        _daño = dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.layer != 7)
        {
            collision.GetComponent<Entity>().DañoRecivido(_daño);
            Destroy(gameObject);
        }
    }

    protected override void OnBecameVisible()
    {
         
    }

}

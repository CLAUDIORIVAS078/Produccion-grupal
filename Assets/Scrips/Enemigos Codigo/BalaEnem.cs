using UnityEngine;

public class BalaEnem : Balas
{
    private void Awake()
    {
        instance = this;
    }
    public override void Daño(int dmg)
    {
        _daño = dmg;
    }
    public override void Desaparece()
    {
        if (_vida <= 0) { Destroy(gameObject); }
        else { _vida -= Time.deltaTime; }
    }

    protected override void OnBecameVisible()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.GetComponent<Player>().DañoRecivido(_daño);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Enemigos : Entity
{
    [SerializeField]
    protected float _rangoVision;
    [SerializeField]
    protected float _rangoAccion;
    [SerializeField]
    protected GameObject _player;

    public override void DañoRecivido(int dañoRes)
    {
        throw new System.NotImplementedException();
    }

    public override void Muerto()
    {
        throw new System.NotImplementedException();
    }
}

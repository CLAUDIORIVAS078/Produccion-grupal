using UnityEngine;
using System.Collections;

public class PleControls
{
    private float _dashForce;
    private PlaMovimiento _movi;
    private Player _player;
    private Vector2 _mousePosition;
    private Transform _mouse;


    public PleControls(PlaMovimiento movi, Player player, float dashForce, Transform mouse)
    {
        _movi = movi;
        _dashForce = dashForce;
        _player = player;
        _mouse = mouse;
    }

    public void ArtificialUpdate()
    {
        Vector2 dir;
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        dir = dir.normalized;
        _movi.Movimiento(dir);


        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _mouse.position = _mousePosition;

        _movi.Rotacion(_mouse);

        _player.CamaraControl(_mouse);

        if (Input.GetKeyDown(KeyCode.Space)) { _movi.Dash(_dashForce); }

        if(Input.GetMouseButtonDown(0)) { _player.Disparo(); }

        if (Input.GetKeyDown(KeyCode.R)) { _player.Recarga(); }
    }
}

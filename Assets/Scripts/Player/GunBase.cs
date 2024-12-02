using UnityEngine;
using UnityEngine.InputSystem;

public abstract class GunBase : MonoBehaviour
{
    public GameObject FireProjectileParticle;
    public GameObject FireParticle;

    protected float FireDelay = 0.5f;
    protected float AltFireDelay = 1.0f;

    private float _delay, _altDelay;

    protected virtual void Start()
    {
        var fire = InputSystem.actions.FindAction("Click");
        var altFire = InputSystem.actions.FindAction("RightClick");

        fire.performed += DoFire;
        altFire.performed += DoAltFire;

        _delay = FireDelay;
        _altDelay = AltFireDelay;
    }

    protected virtual void Update()
    {
        _delay -= Time.deltaTime;
        if (_delay <= 0) _delay = FireDelay;

        _altDelay -= Time.deltaTime;
        if (_altDelay <= 0) _altDelay = AltFireDelay;
    }

    protected abstract void DoFire(InputAction.CallbackContext ctx);
    protected abstract void DoAltFire(InputAction.CallbackContext ctx);
}

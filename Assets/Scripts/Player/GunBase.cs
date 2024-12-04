using UnityEngine;
using UnityEngine.InputSystem;

public abstract class GunBase : MonoBehaviour
{
    public GameObject FireProjectile;
    public GameObject FireParticle;

    protected float FireDelay = 0.5f;
    protected float AltFireDelay = 1.0f;

    protected float _delay, _altDelay;

    protected virtual void Start()
    {
        var fire = InputSystem.actions.FindAction("Click");
        var altFire = InputSystem.actions.FindAction("RightClick");

        fire.performed += DoFire;
        altFire.performed += DoAltFire;
    }

    protected virtual void Update()
    {
        _delay -= Time.deltaTime;
        _altDelay -= Time.deltaTime;
    }

    protected abstract void DoFire(InputAction.CallbackContext ctx);
    protected abstract void DoAltFire(InputAction.CallbackContext ctx);

    private void OnDestroy()
    {
        var fire = InputSystem.actions.FindAction("Click");
        var altFire = InputSystem.actions.FindAction("RightClick");

        fire.performed -= DoFire;
        altFire.performed -= DoAltFire;
    }
}

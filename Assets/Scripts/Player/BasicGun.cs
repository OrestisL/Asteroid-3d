using UnityEngine;
using UnityEngine.InputSystem;

public class BasicGun : GunBase
{
    public Transform[] InstantiationPoints;

    protected override void Start()
    {
        base.Start();
        FireDelay = 0.3f;
    }

    protected override void DoAltFire(InputAction.CallbackContext ctx)
    {

    }

    protected override void DoFire(InputAction.CallbackContext ctx)
    {
        if (_delay > 0)
            return;

        for (int i = 0; i < InstantiationPoints.Length; i++) 
        {
            GameObject projectile = Instantiate(FireProjectile, InstantiationPoints[i].position, Quaternion.identity);
        }

        _delay = FireDelay;
    }
}

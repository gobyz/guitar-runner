using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Ability
{
    public override void ActivateAbility()
    {
        PickController.instance.ImmunityEffectOn();

        Player.instance.isImmuneToDamage = true;
    }

    public override void DeactivateAbility()
    {
        PickController.instance.ImmunityEffectOff();

        Player.instance.isImmuneToDamage = false;
    }
}

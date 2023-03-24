using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detach : Ability
{
    public Pool evilNotesPool;

    public Pool evilNotesJumpingPool;
    public override void ActivateAbility()
    {
        
    }
    public override void DeactivateAbility()
    {
        
    }
    public void DetachAll()
    {
        if (abilityActivated)
        {
            foreach (Entity entity in evilNotesPool.entities)
            {
                EvilNote en = (EvilNote)entity;

                if (!en.isAvailable)
                {
                    if (en.guitarString == PickController.instance.GetCurrentGuitarString())
                    {
                        en.Detach();
                    }
                }
            }

            foreach (Entity entity in evilNotesJumpingPool.entities)
            {
                EvilNote en = (EvilNote)entity;

                if (!en.isAvailable)
                {
                    if (en.guitarString == PickController.instance.GetCurrentGuitarString())
                    {
                        en.Detach();
                    }
                }
            }
        }     
    }
}

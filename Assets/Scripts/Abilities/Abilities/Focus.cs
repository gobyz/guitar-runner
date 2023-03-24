using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : Ability
{
    public Pool goodNotesPool;

    public Pool goodNotesJumpingPool;

    public override void DeactivateAbility()
    {
        
    }
    public override void ActivateAbility()
    {
        FocusNotes();
    }

    public void FocusNotes()
    {
        foreach(Entity goodNote in goodNotesPool.entities)
        {
            GoodNote gn = (GoodNote)goodNote;
            
            if (!gn.isAvailable)
            {
                gn.FocusToGuitarString(PickController.instance.GetCurrentGuitarString());
            }
        }

        foreach (Entity goodNote in goodNotesJumpingPool.entities)
        {
            GoodNote gn = (GoodNote)goodNote;

            if (!gn.isAvailable)
            {
                gn.GetComponent<JumpNote>().SetToFinished();

                gn.FocusToGuitarString(PickController.instance.GetCurrentGuitarString());
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class DefenderBow : Defender {

    public override void OnFixedUpdate()
    {
        switch (action)
        {
            case actions.ATTACKING:
                attack.FixedUpdateByManager();
                break;
        }
    }

}

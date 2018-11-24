using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorClass : ClassBase {

    // Use this for initialization
    public override void CreateCanvas(float currentHP, float maxHP)
    {
        CreateClassCanvas("Warrior", currentHP, maxHP);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyBat : Enemy
{
    public float health;

    // Use this for initialization
    void Start() {
        SetHealth(health);

    }

    public override void SendToFactory()
    {
        BatFactory.Recycle(this.gameObject);
    }

    // Update is called once per frame
    void Update() {

    }
}

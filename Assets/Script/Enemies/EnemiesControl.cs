using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControl : MovingObject {
    public GameObject Bar;
    LifeBar lifeBar;
    int life;
	// Use this for initialization
	protected override void Start ()
    {
        lifeBar = Bar.transform.GetComponent<LifeBar>();
        life = 10;
	}

    protected override void LoseLife(float pourcentage)
    {
        if (!lifeBar.UpdateLifeBar(pourcentage))
            Drown();
    }
}

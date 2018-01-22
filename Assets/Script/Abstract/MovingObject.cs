using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public abstract class MovingObject : NetworkBehaviour{
    bool isDrowning = false;
    protected virtual void Start()
    {

    }
	protected virtual void Drown()
    {
        transform.GetComponent<Rigidbody>().isKinematic = true;
        isDrowning = true;
    }
    public void HitAngle(float rotY)
    {
        if(rotY < 91)
        {
            if(rotY > 74)
            {
                LoseLife(.90f);
            }
            else if(rotY > 30)
            {
                LoseLife(.40f);
            }
            else
            {
                LoseLife(.10f);
            }
        }
        else
        {
            if (rotY < 106)
            {
                LoseLife(.90f);
            }
            else if (rotY < 150)
            {
                LoseLife(.40f);
            }
            else
            {
                LoseLife(.10f);
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDrowning)
        {
            transform.Rotate(0f, 0f, 5 * Time.deltaTime);
            transform.Translate(0f, -0.3f * Time.deltaTime, 0f);
        }
    }
    protected virtual void LoseLife(float pourcentage) { }
}

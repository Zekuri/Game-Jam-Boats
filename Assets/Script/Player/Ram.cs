using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MonoBehaviour {
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.contacts[0].thisCollider.name == "Ram")
        {
            if (collision.contacts[0].otherCollider.name == "Coque")
            {
                float t_rotY = collision.transform.rotation.y;
                t_rotY = Vector3.Angle(transform.position - collision.transform.position, Vector3.forward);
                collision.gameObject.GetComponent<MovingObject>().HitAngle(t_rotY);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject BulletEntity;
    [SerializeField]
    float projectileSpeed = 7f;
    float entityExpiryDistance = 100f;
    float entityExpiryLifetime = 100f;
    Vector3 VelocityVector = Vector3.zero;
    // Start is called before the first frame update
    void
	Start()
    {

    }

    // Update is called once per frame
    void
	Update()
    {
	transform.Translate(Vector3.forward *
			    Time.deltaTime *
			    projectileSpeed);
    }
}

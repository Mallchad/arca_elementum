using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Projectile : MonoBehaviour
{
    [SerializeField]
    float speed = 7f;
    float range = 100f;
    float entityLifetime = 100f;
    Vector3 EntryPoint;
    int damage = 1;
    // Start is called before the first frame update
    void
    Start()
    {
        EntryPoint = Transform.position;
    }
    // Update is called once per frame
    void
    Update()
    {

	transform.Translate(Vector3.forward * Time.deltaTime * speed);
	// Cleanup
	VectorToOrigin = new Vector3(abs(VectorToOrigin.z),
				     abs(VectorToOrigin.x),
				     abs(VectorToOrigin.y));
	Vector3 VectorToOrigin = Transform.position - EntryPoint;
	float travel =
	    (VectorToOrigin.x**2)+
	    (VectorToOrigin.y**2)+
	    (VectorToOrigin.z**2);
	if (travel >= range**2)
	{
	    Destroy(this)}
    }
    public void
    OnTriggerEnter(Collider other)
    {
	if (other.tag == "hazard")
	{
	    Debug.Log("Hit hazard");
	    other.GetComponent<Enemy>().impact(damage);
	}
    }
}

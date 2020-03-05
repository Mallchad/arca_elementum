using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Player : MonoBehaviour
{
    [SerializeField]
    public Camera viewpoint;
    Rigidbody rb;
    Vector3 moveInput;
    Vector3 moveVelocity;
    bool isFiring = false;
    float timeOfLastShot = Time.time;
    [SerializeField]
    Weapon EquippedWeapon;
    // Start is called before the first frame update
    void
    Start()
    {
	EquippedWeapon = FindObjectOfType<Weapon>();
	rb = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void
    Update()
    {
        //Use a raycast to make the player face the direction of the mouse

        // Create a new "plane" for our ray to "collide" with
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        // Create the ray fro mthe camera towards the mouse position
        Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        // Create a hit point for the distance to the position of where the ray hits hte plane
        float hitPoint = 0f;
        // Check to see if the plane is being hit by the ray, output the hit point distance
        if (playerPlane.Raycast(ray, out hitPoint))
        {
            // Create a vector to hold the coords of the hitpoint
            Vector3 targetPoint = ray.GetPoint(hitPoint);
            // Rotate the player to face the target point
            Quaternion targetRotation =
		Quaternion.LookRotation(targetPoint-transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            // Set the transform
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  targetRotation,
                                                  7f * Time.deltaTime);
        }

        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),
                                0f,
                                Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput + moveVelocity;
	if (Input.GetMouseButtonDown(0))
	{
	    isFiring = true;
	}
    }
    void
    fixedUpdate()
    {//
        rb.velocity = moveVelocity;
    }
    void firingWeapon()
    {
	if (isFiring)
	{
	    float timeSinceLastShot = timeOfLastShot - Time.time;
	    EquippedWeapon.fire();
	}

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Weapon : MonoBehaviour
{
    [SerializeField]
    int ammoRemaining = 30;
    [SerializeField]
    int ammoMaximum = 30;
    float fireRate;
    GameObject BulletSpawnPoint;
    public GameObject Bullet;
    UnityEngine.UI.Text ammoDisplay;
    // Start is called before the first frame update
    void Start()
    {
	    BulletSpawnPoint = GameObject.FindWithTag("bullet_spawn_point");
	    ammoDisplay = GameObject
	    .Find("AmmoCounter")
	    .GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = ammoRemaining + "/" + ammoMaximum;
    }
    public bool fire()
    {
	if (ammoRemaining > 0)
	{
	    GameObject projectile =
		Instantiate(Bullet,
			    BulletSpawnPoint.transform.position,
			    BulletSpawnPoint.transform.rotation);
	    // Play a sound
	    // Play an animation
	    // Play particle effects
	    // Make a reload command
	    return true;
	}
	return false;
    }
}

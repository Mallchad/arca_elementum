using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health;
    int defense = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void
    defeated()
    {
	Debug.Log("Enemy has been killed!");
	Destroy(this.gameObject);
    }
    int hit(int incomingDamage)
    {
	health -= resultantDamage;
	resultantDamage = incomingDamage / (defense+1);
	return resultantDamage;
    }
}

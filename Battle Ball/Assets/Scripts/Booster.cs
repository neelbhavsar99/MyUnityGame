using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D col)
	{
		Rigidbody2D boost;
		float originalMass;
		boost = col.gameObject.GetComponent<Rigidbody2D>();
		boost.isKinematic = true;
		boost.isKinematic = false;
		originalMass = boost.mass;
		boost.mass = 1f;
		col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*9, ForceMode2D.Impulse);
		boost.mass = originalMass;
        xa.audioManager.PlayBounce();
	}

}

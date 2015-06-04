using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gacha : MonoBehaviour {
	public float coolDown;
	public List<Weapon> possibleWeapons;

	void OnTriggerEnter2D(Collider2D collider){

		if (collider.tag == "Player") {
			Player p = collider.GetComponent<Player>();
			p.currentWeapon = possibleWeapons[Random.Range(0, possibleWeapons.Count)];
		}
	}
}

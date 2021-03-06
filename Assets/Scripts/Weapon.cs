﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float distance;
	public int damages;
	public float frequency;

	private bool canShoot;
	void Start(){
		StartCoroutine (ShootFrequency ());
	}

	public virtual void Attack(Enemy mob){
		if (canShoot) {
			mob.life -= damages;
			canShoot = false;
		}
	}

	IEnumerator ShootFrequency(){
		for (;;) {
			canShoot = true;
			yield return new WaitForSeconds(frequency);
		}
	}
}

﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 150f;
	private Vector3 target;
	public int currentGold = 100;
	private bool isAttacking = false;
	private GameObject cible;
	public Weapon currentWeapon;
	void Start () {
		target = transform.position;
	}
	
	void Update () {

		if (Input.GetMouseButton(0)) {

			CheckObjectAimed(Input.mousePosition);
		}
		if(isAttacking == false)
		{
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		}
		else{
			if(cible != null)
			Attack(cible);
			else{
				isAttacking = false;
			}
		}
	} 

	private void CheckObjectAimed(Vector3 mousePosition){

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
			{
				switch (hit.collider.tag)
				{
					case "MapWalkable":
						isAttacking = false;
						MoveTo(mousePosition);
						break;
					case "Enemy":
							isAttacking = true;
							cible = hit.collider.gameObject;
							Attack(cible);
						break;
				
				}

			}

	}

	private void MoveTo(Vector3 mousePosition)
	{
		target = Camera.main.ScreenToWorldPoint(mousePosition);
		target.z = transform.position.z;

	}

	private void Attack(GameObject enemy)
	{

		float distToCible = Vector3.Distance(transform.position, enemy.transform.position);

		if(currentWeapon.distance < distToCible)
		{
			Debug.Log ("reaching enemy");
			target = enemy.transform.position;
			target.z = transform.position.z;
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		}
		else{
			Debug.Log ("attackEnemy");
			target = transform.position;
			currentWeapon.Attack(enemy.GetComponent<Enemy>());
		}

	}
}

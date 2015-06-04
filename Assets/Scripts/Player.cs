using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 150f;
	private Vector3 target;
	private bool isAttacking = false;

	//public Weapon currentWeapon;
	void Start () {
		target = transform.position;
	}
	
	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			CheckObjectAimed(Input.mousePosition);
		}

	} 

	private void CheckObjectAimed(Vector3 mousePosition){

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 100))
			{
				switch (hit.collider.tag)
				{
					case "MapWalkable":
						MoveTo(mousePosition);
						break;
					case "Enemy":
				Attack(hit.collider.gameObject);
						break;
				
				}

			}

	}

	private void MoveTo(Vector3 mousePosition)
	{
		target = Camera.main.ScreenToWorldPoint(mousePosition);
		target.z = transform.position.z;
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}

	private void Attack(GameObject enemy)
	{

	}
}

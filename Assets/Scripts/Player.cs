using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 150f;
	private Vector3 target;

	public PlayerWeapon currentWeapon;
	void Start () {
		target = transform.position;
	}
	
	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
		}
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}    

}

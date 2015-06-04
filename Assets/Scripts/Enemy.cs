using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class Enemy : MonoBehaviour {
	public int baseLife;

	[HideInInspector]
	public int life;

	private bool willDie;
	void Start(){
		life = baseLife;
	}

	void Update(){
		Debug.Log (life);
		if (willDie) {
			Destroy(gameObject);
		}

		if (life <= 0) {
			willDie = true;
		}
	}
}

using UnityEngine;
using System.Collections;

public class OldingGuy : MonoBehaviour {
	public Color baseColor = Color.blue;
	public Color targetColor = Color.red;
	public float lerpingSpeed;

	void Awake(){
		GetComponent<Renderer> ().material.color = baseColor;
	}

	void Update(){
		GetComponent<Renderer> ().material.color = Color.Lerp (GetComponent<Renderer> ().material.color, targetColor, lerpingSpeed * Time.deltaTime);
	}
}

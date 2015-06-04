using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFollower : MonoBehaviour {
	public List<Transform> paths;
	public float speed;
	public bool randomChoosing;

	private int currentIndex;

	void Update(){
		CheckCurrentDistance ();

		transform.position = Vector3.MoveTowards (transform.position, paths [currentIndex].position, speed * Time.deltaTime);
	}

	void CheckCurrentDistance(){
		if(Vector2.Distance(transform.position, paths[currentIndex].position) <= 0.1f){
			if(randomChoosing){
				currentIndex = Random.Range(0, paths.Count);
			}else{
				if(currentIndex >= paths.Count-1){
					currentIndex = 0;
				}else{
					currentIndex++;
				}
			}
		}
	}
}

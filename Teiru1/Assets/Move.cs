using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	float speed = 450.0f;
	
	void Update() {

		var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
		int DistanceAway = 310;
		Vector3 PlayerPOS = GameObject.Find("Player").transform.transform.position;
		GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway);
	}
}
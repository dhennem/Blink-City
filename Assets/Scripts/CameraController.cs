using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	

	public PlayerController player;
	public float followSmoothness; //only used for FlyingCombat state
	public PlayerSpawner playerSpawner;

	private Vector3 offset;
	private Vector3 currentVelocity;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(player!=null){
			if(player.currentState == PlayerController.PlayerState.OutOfCombat){
				Vector3 unboundedCameraPos = player.transform.position + offset;
				float cameraXPos = Mathf.Clamp(unboundedCameraPos.x, 5f, 52f);
				float cameraYPos = 5f; 
				float cameraZPos = unboundedCameraPos.z;

				transform.position = new Vector3(cameraXPos, cameraYPos, cameraZPos);
			}
		}
		else{
			player = FindObjectOfType<PlayerController>();
			offset = transform.position - player.transform.position;
		}
	}

	//need to manage Flying Combat camera follow in here so that camera pos is always updated after player pos
	void LateUpdate(){
		if(player!=null){
			if(player.currentState == PlayerController.PlayerState.FlyingCombat){
				if(player.transform.position.y > transform.position.y){ //only follow player upwards, not downwards
					Vector3 newCameraPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
					transform.position = Vector3.SmoothDamp(transform.position, newCameraPos, ref currentVelocity, followSmoothness);
					//camera follow is not immediate, the followSmoothness makes a delay
				}
			}
		}
	}
}

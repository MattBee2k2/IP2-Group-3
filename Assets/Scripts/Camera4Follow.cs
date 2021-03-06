﻿using UnityEngine;
using System.Collections;

public class Camera4Follow : MonoBehaviour 
{
	public Camera mainCamera;
	public Camera camera2;

	public float dampTime = 0f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//Follows the target(which is the player) NOTE: This piece of code was taken from the unity forums
		if (target && camera2.enabled == true)
		{
			Vector3 point = camera2.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera2.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			mainCamera.enabled = false;
			camera2.enabled = true;
		}
	}
}

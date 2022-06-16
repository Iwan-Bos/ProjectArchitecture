using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickup : MonoBehaviour
{

	public GameObject plant1;
	public GameObject plant2;

	// Start is called before the first frame update
	void Start()
	{

	}

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}


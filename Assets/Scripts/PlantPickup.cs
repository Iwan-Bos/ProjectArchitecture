using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickup : MonoBehaviour
{

	public GameObject[] plantArray = new GameObject[8];
	private static bool carrying = false;
	public GameObject plant_dropped;
	bool plant_scanner;
	public static GameObject plant_pickedup;



	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(PlantPickup.carrying);
		if (!PlantPickup.carrying) {

			if (other.CompareTag("Player")) {

				GameObject plant = this.gameObject;

				
				//carrying coderen voor 1 plant
				
				plant.SetActive(false);
				PlantPickup.carrying = true;
				Debug.Log("You're carrying a plant.");
				plant_scanner = true;
				plant_pickedup = plant;

			}
		}

		else {
		
			//carrying coderen voor meer dan 2 planten
			
			Debug.Log("You cannot carry more items.");
		}
	}

	private void Start()
	{
	
		plantArray = GameObject.FindGameObjectsWithTag("plant");
	}

	private void Update()
	{

		this.drop();
	}

	private void drop()
	{
		if (Input.GetKeyDown(KeyCode.Q) && PlantPickup.carrying == true)
		{
			Debug.Log("drop");

				GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
				plant_pickedup.SetActive(true);
				plant_pickedup.transform.position = new Vector3(playerObj.transform.position.x, plant_pickedup.transform.position.y , playerObj.transform.position.z+4);
			
				plant_pickedup = null;
				PlantPickup.carrying = false;
	


			//  }
		}
	}
	
	private void OnTriggerExit(Collider collision)
	{
		if (collision.CompareTag("plant"))
		{
			plant_scanner = false;

		}
	}
}
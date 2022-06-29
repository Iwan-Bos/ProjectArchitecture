using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickup : MonoBehaviour
{

	public GameObject[] plantArray = new GameObject[8];
	private static bool carrying = false;
	public GameObject plant_dropped;


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

	private void drop()
	{
		if (Input.GetKeyDown(KeyCode.Q) && carrying == true)
		{
			carrying = false;
			GameObject plant = this.gameObject;
			if (plant.activeSelf == true)
			{
				plant.SetActive(false);
				plant = null; 
				plant_dropped = Instantiate(plant_dropped, transform.position, Quaternion.identity); 

			  }
		}
	}
	
	private void OnTriggerExit(Collider collision)
	{
		if (collision.CompareTag("plant"))
		{
			

		}
	}
}
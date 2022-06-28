using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickup : MonoBehaviour
{




	public GameObject[] myPlantArray = new GameObject[8];
	private static bool carrying = false;


	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(PlantPickup.carrying);
		if (!PlantPickup.carrying)
		{
			if (other.CompareTag("Player"))
			{
	
			
				GameObject plant = this.gameObject;
				

				
				//carrying coderen voor 1 plant
				plant.SetActive(false);
				PlantPickup.carrying = true;
					Debug.Log("You're carrying a plant.");
					
						
				
			}
		}

		else
			{
	
	//			//carrying coderen voor meer dan 2 planten
	
			Debug.Log("You cannot carry more items.");
				

			}


		
	}

	private void Start()
	{
	
		myPlantArray = GameObject.FindGameObjectsWithTag("plant");
		

	}
}


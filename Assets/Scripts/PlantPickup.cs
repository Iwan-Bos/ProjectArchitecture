using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickup : MonoBehaviour
{


	string[] myPlantArray = { "Plant1", "Plant2", "Plant3", "Plant4", "Plant5", "Plant6", "Plant7", "Plant8" };
	public GameObject[] plants;
	private bool carrying = false;


	private void OnTriggerEnter(Collider other)
	{
		if (!carrying)
		{

			if (other.CompareTag("Player"))
			{
				//carrying coderen voor meer dan 2 planten

				plants.SetActive(true);
				carrying = true;
				Console.WriteLine("You're carrying plant 1.");
			}

			else
			{
				plants.SetActive(false);
				Console.WriteLine("You cannot carry more items.");
			}
		}
	}

	private void Start()
	{
		plants = GameObject.FindGameObjectsWithTag("Plant");

	}
}


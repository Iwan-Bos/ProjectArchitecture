using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickup : MonoBehaviour
{

	
	public GameObject plant1;
	private bool carrying = false;


	private void OnTriggerEnter(Collider other)
	{
		if (!carrying)
		{

			if (other.CompareTag("Player"))
			{
				//carrying coderen voor meer dan 2 planten

				plant1.SetActive(true);
				carrying = true;
				Console.WriteLine("You're carrying plant 1.");
			}

			else
			{
				plant1.SetActive(false);
				Console.WriteLine("You cannot carry more items.");
			}
		}
	}
}


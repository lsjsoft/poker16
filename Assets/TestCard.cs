﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestCard : MonoBehaviour {

	public PlayerCardList pcl;

	private System.Random random = new System.Random ();
	public void AddTestCard()
	{
		PlayerCards pc = new PlayerCards ();

		for (int i = 0; i < 10; ++i) 
		{
			PlayerCard p = new PlayerCard ();
			p.color = (CardColor) random.Next (1, 4);
			p.value = (ushort)random.Next (3, 15);
			pc.cards.Add (p);
		}

		pcl.ShowCardList (pc);
	}
}

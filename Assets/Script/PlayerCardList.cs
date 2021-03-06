﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardList : MonoBehaviourX
{
	public GameObject cardTemplate;
	public List<GameObject> allCardObjects = new List<GameObject> ();

	void Start ()
	{
		scope.Listen ("PlayerSelectCardList", delegate(object[] args) 
		{
			int fd = (int)(args[0]);	
			int sd = (int)(args[1]);
			for (int i = 0; i < allCardObjects.Count; ++i) 
			{
				PokerControl p = allCardObjects[i].GetComponent<PokerControl> ();
				bool selected = p.ShowIndex >= fd && p.ShowIndex <= sd;
				p.SetSelectState(selected);
			}
		});
	}

	void ClearOldCard()
	{
		for (int i = 0; i < allCardObjects.Count; ++i) 
		{
			GameObject.Destroy (allCardObjects [i]);
		}
		allCardObjects.Clear ();
	}

	public List<PlayerCard> PickSelectCards()
	{
		List<PlayerCard> list = new List<PlayerCard> ();
		for (int i = 0; i < allCardObjects.Count; ++i) 
		{
			PokerControl p = allCardObjects[i].GetComponent<PokerControl> ();
			if (p.isSelected) 
			{
				list.Add (p.GetCard ());
			}
		}
		return list;
	}

	public void ShowCardList(PlayerCards playcards)
	{
		ClearOldCard ();

		Vector3 pos = Vector3.zero;
		for (int i = 0; i < playcards.cards.Count; ++i) 
		{
			GameObject childCard = GameObject.Instantiate (cardTemplate);
			childCard.transform.parent = gameObject.transform;
			childCard.name = string.Format ("card{0}", i);
			allCardObjects.Add (childCard);

			PokerControl p = childCard.GetComponent<PokerControl> ();
			p.SetCard (playcards.cards [i]);
			p.SetDepth (i);
			p.ShowIndex = i;

			childCard.transform.localPosition = pos;
			childCard.transform.localScale = Vector3.one;

			pos.x = pos.x + 20;
		}
	}

}


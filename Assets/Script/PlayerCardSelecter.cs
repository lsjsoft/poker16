using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardSelecter : MonoBehaviourX 
{
	private GameObject firstSelectCardObj = null;

	void Start () 
	{
		scope.Listen ("BatchSelectCardBegin", delegate(object[] args) 
		{
			firstSelectCardObj = (GameObject)args[0];
		});

		scope.Listen ("BatchSelectCardEnd", delegate(object[] args) 
		{
			UpdateSelect( firstSelectCardObj, (GameObject)args[0]);
			firstSelectCardObj = null;
		});

		scope.Listen ("BatchSelectCardHover", delegate(object[] args) 
		{
			UpdateSelect( firstSelectCardObj, (GameObject)args[0]);
		});
	}

	int GetCardIndex(GameObject obj)
	{
		return obj.transform.parent.GetComponent<PokerControl> ().ShowIndex;
	}

	void UpdateSelect(GameObject first, GameObject second)
	{
		if (first != null && second != null) 
		{
			int fd = GetCardIndex (first);
			int sd = GetCardIndex (second);
			if (fd < sd) 
			{
				Eventer.Fire ("PlayerSelectCardList", new object[] { fd, sd });
			} else if (sd < fd) 
			{
				Eventer.Fire ("PlayerSelectCardList", new object[] { sd, fd });
			}
		}
	}
}

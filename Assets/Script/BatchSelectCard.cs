using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchSelectCard : MonoBehaviour
{
	bool bPress = false;
	GameObject firstSelObj = null;

	void Start()
	{
		UIEventListener.Get (gameObject).onPress = delegate(GameObject go, bool state) 
		{
			bPress = state;

			if (state)
			{
				Eventer.Fire("BatchSelectCardBegin", new object[] { go } );
			}
			else
			{
				Eventer.Fire("BatchSelectCardEnd", new object[] { go } );
			}
		};
	}

	void Update()
	{
		if (bPress) 
		{
			if (UICamera.Raycast ( new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)))
			{
				Eventer.Fire ("BatchSelectCardHover", new object[] { UICamera.lastHit.collider.gameObject });
			}
		}
	}
}

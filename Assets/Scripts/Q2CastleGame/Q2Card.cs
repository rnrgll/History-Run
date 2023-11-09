using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q2Card : MonoBehaviour
{
	public bool select;
	public bool answer;
	//카드를 trace하는 변수
	public int cardIndex;

	public Q2CardGameManager gm;
		public AudioSource selectSound;



	private void Start()
	{ 
		
		select = false;
	}
	private void OnMouseDown()
	{
		selectSound.Play();
		if (!select)
		{
			transform.GetComponent<SpriteRenderer>().color = new Color(0.5817267f,0.9528302f,0.3370862f);
			select = true;
			gm.SelectSlots[cardIndex] = true;
						
		}
		else {
			transform.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
			select = false;
			gm.SelectSlots[cardIndex] = false;
		}

	}


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q1Card : MonoBehaviour
{
	public bool select;
	public bool answer;
	//카드를 trace하는 변수
	public int cardIndex;

	public Q1CardGameManager gm;
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
			transform.GetChild(0).gameObject.SetActive(true);
			select = true;
			gm.SelectSlots[cardIndex] = true;

		}
		else
		{
			transform.GetChild(0).gameObject.SetActive(false);
			select = false;
			gm.SelectSlots[cardIndex] = false;
		}

	}


}
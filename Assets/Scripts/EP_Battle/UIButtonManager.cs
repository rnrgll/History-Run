using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    GameObject player;
    PlayerMoveButton playerMoveButton;
    Weapon weapon;

    void Start()
    {
        player = GameObject.Find("Player");
        playerMoveButton = player.GetComponent<PlayerMoveButton>();
        weapon = player.GetComponent<Weapon>();
    }
    public void LeftDown()
    {
        playerMoveButton.inputLeft = true;
    }
    public void RightDown()
    {
        playerMoveButton.inputRight = true;
    }

    public void LeftUp()
    {
         playerMoveButton.inputLeft = false;
    }
    public void RightUp()
    {
        playerMoveButton.inputRight = false;
    }

    public void JumpClick()
    {
        playerMoveButton.inputJump = true;
    }

    public void AttackClick()
    {
        weapon.inputAttack = true;
    }



}

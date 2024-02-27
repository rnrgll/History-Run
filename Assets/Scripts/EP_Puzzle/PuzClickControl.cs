using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzClickControl : MonoBehaviour
{
    private BoxCollider2D[] puzPieces;

    public void puzPieceOff()
    {
        puzPieces = GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D puzPiece in puzPieces)
        {
            if (puzPiece != null)
            {
                puzPiece.enabled = false;
            }
            else
            {
                Debug.Log("puzzle piece is null");
            }
        }
    }

    public void puzPieceOn()
    {
        foreach (BoxCollider2D puzPiece in puzPieces)
        {
            if (puzPiece != null)
            {
                puzPiece.enabled = true;
            }
            else
            {
                Debug.Log("puzzle piece is null");
            }
        }
    }
}

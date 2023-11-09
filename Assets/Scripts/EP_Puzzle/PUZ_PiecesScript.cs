using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PUZ_PiecesScript : MonoBehaviour
{
    private Vector3 RightPosition;

    public bool InRightPosition;

    public bool Selected;

    private PUZ_DragAndDrop _puzDragAndDrop;

    private int pieces = 16;

    public AudioSource audioSource_place;

    
    // Start is called before the first frame update
    void Start()
    {
        RightPosition = transform.localPosition;
        // transform.localPosition = new Vector3(-4, -10);
        transform.localPosition = new Vector3(Random.Range(-6f, 4f), Random.Range(-19f, -9f));

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.localPosition, RightPosition) < 0.5f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.localPosition = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 2;
                    _puzDragAndDrop = GameObject.Find("Puzzles").GetComponent<PUZ_DragAndDrop>();
                    audioSource_place.Play();
                    _puzDragAndDrop.puzzlePlaced();
                    
                }
                
            }
        }
    }
}
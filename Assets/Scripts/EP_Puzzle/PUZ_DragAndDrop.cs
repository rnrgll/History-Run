using UnityEngine;
using UnityEngine.Rendering;

public class PUZ_DragAndDrop : MonoBehaviour
{
    public GameObject SelectedPiece;

    public int correctPieces;

    private int OIL = 3;

    public AudioSource audioSource_bgm;
    public AudioSource audioSource_click;

    public AudioSource audioSource_done;
    public GameObject passPanel;
    public GameObject gameUICanvas;


    private int pieces = 16;

    // Start is called before the first frame update
    void Start()
    {
        correctPieces = 0;
        audioSource_bgm.Play();
    }

    public void puzzlePlaced()
    {
        correctPieces++;
        if (correctPieces == pieces)
        {
            gameUICanvas.SetActive(false);
            audioSource_bgm.Stop();
            audioSource_done.Play();

            passPanel.SetActive(true);
            PlayerPrefs.SetString("EpiloguePlayLog", "PuzzleGameClear");

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null && hit.transform.CompareTag("PUZ"))
                {
                    if (!hit.transform.GetComponent<PUZ_PiecesScript>().InRightPosition)
                    {
                        SelectedPiece = hit.transform.gameObject;
                        SelectedPiece.GetComponent<PUZ_PiecesScript>().Selected = true;
                        audioSource_click.Play();
                        SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                        OIL++;
                        break;
                    }
                }
            }
            // RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            // if (hit.collider != null)
            // {
            //     if (hit.transform.CompareTag("PUZ"))
            //     {
            //         if (!hit.transform.GetComponent<PUZ_PiecesScript>().InRightPosition)
            //         {
            //             SelectedPiece = hit.transform.gameObject;
            //             SelectedPiece.GetComponent<PUZ_PiecesScript>().Selected = true;
            //             audioSource_click.Play();
            //             SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
            //             OIL++;
            //         }
            //     }
            // }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<PUZ_PiecesScript>().Selected = false;
                SelectedPiece = null;
                // if (SelectedPiece.GetComponent<PUZ_PiecesScript>().InRightPosition == true)
                // {
                //     Debug.Log("check");
                // }
            }

        }

        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }

    }
}

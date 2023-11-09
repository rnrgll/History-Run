
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Doublsb.Dialog;

public class Q4button : MonoBehaviour, IPointerClickHandler
{
    public DialogManager dialogManager;
    public GameObject ImgPanel;
    public Quest4 q4;

     public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {

            gameObject.SetActive(false);
            ImgPanel.SetActive(false);
            gameObject.transform.parent.gameObject.SetActive(false);
            q4.UpdatePlayLog("#1");
            


        }
    }
}

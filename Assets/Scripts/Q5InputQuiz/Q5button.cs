
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Doublsb.Dialog;

public class Q5button : MonoBehaviour, IPointerClickHandler
{
    public DialogManager dialogManager;
    public GameObject ImgPanel;
    public Quest5 q5;

     public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {

            gameObject.SetActive(false);
            ImgPanel.SetActive(false);
            gameObject.transform.parent.gameObject.SetActive(false);
            q5.UpdatePlayLog("#1");
            


        }
    }
}

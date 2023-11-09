
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Doublsb.Dialog;

public class Q6button : MonoBehaviour, IPointerClickHandler
{
    public DialogManager dialogManager;
    public GameObject ImgPanel;
    public Quest6 q6;

     public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {

            gameObject.SetActive(false);
            ImgPanel.SetActive(false);
            gameObject.transform.parent.gameObject.SetActive(false);
            q6.UpdatePlayLog("#1");
            


        }
    }
}

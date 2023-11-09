
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Doublsb.Dialog;

public class UIMouseClick : MonoBehaviour, IPointerClickHandler
{
    public DialogManager dialogManager;
    public GameObject ImgPanel;
    public AudioSource sound;

     public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {

            gameObject.SetActive(false);
            ImgPanel.SetActive(false);
            gameObject.transform.parent.gameObject.SetActive(false);
            Debug.Log("click");
            dialogManager.Click_Window();
            sound.Play();


        }
    }
}

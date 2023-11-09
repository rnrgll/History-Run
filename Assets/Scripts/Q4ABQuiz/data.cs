using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Data : MonoBehaviour
{
    public TextMeshProUGUI tmp_yeom;
    public TextMeshProUGUI tmp_sinche;
    public TextMeshProUGUI tmp_jineung;
    public TextMeshProUGUI tmp_insung;
    public TextMeshProUGUI tmp_jikkam;
    public TextMeshProUGUI tmp_luck;

    private string pPK_yeom = "yeom";
    private string pPK_sinche = "sinche";
    private string pPK_jineung = "jineung";
    private string pPK_insung = "insung";
    private string pPK_jikkam = "jikkam";
    private string pPK_luck = "luck";

    public int int_yeom = 0;
    public int int_sinche = 0;
    public int int_jineung = 0;
    public int int_insung = 0;
    public int int_jikkam = 0;
    public int int_luck = 0;

    public void Setting() {
        PlayerPrefs.SetString("염력", "yeom");
        PlayerPrefs.SetString("신체", "sinche");
        PlayerPrefs.SetString("지능", "jineung");
        PlayerPrefs.SetString("인성", "insung");
        PlayerPrefs.SetString("직감", "jikkam");
        PlayerPrefs.SetString("운", "luck");
    }



    public void Save()
    {
        PlayerPrefs.SetInt(pPK_yeom, int_yeom);
        tmp_yeom.text = int_yeom.ToString();

        PlayerPrefs.SetInt(pPK_sinche, int_sinche);
        tmp_sinche.text = int_sinche.ToString();

        PlayerPrefs.SetInt(pPK_jineung, int_jineung);
        tmp_jineung.text = int_jineung.ToString();

        PlayerPrefs.SetInt(pPK_insung, int_insung);
        tmp_insung.text = int_insung.ToString();

        PlayerPrefs.SetInt(pPK_jikkam, int_jikkam);
        tmp_jikkam.text = int_jikkam.ToString();

        PlayerPrefs.SetInt(pPK_luck, int_luck);
        tmp_luck.text = int_luck.ToString();
    }

    public void Load()
    {
        int_yeom = PlayerPrefs.GetInt(pPK_yeom);
        tmp_yeom.text = int_yeom.ToString();

        int_sinche = PlayerPrefs.GetInt(pPK_sinche);
        tmp_sinche.text = int_sinche.ToString();

        int_jineung = PlayerPrefs.GetInt(pPK_jineung);
        tmp_jineung.text = int_jineung.ToString();

        int_insung = PlayerPrefs.GetInt(pPK_insung);
        tmp_insung.text = int_insung.ToString();

        int_jikkam = PlayerPrefs.GetInt(pPK_jikkam);
        tmp_jikkam.text = int_jikkam.ToString();

        int_luck = PlayerPrefs.GetInt(pPK_luck);
        tmp_luck.text = int_luck.ToString();
    }
}
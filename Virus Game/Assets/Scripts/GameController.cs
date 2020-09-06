using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public GameObject virusPrefab;
    public Text virusMoneyText;
    public Text apsText;
    public float virusMoney;
    public float virusGainPerClick = 1f;
    public float virusGainPerSec = 0f;
    public GameObject shadowPanel;
    public GameObject upgradeMenuPanel;
    public UpgradeMenuController umc;

    private void Start()
    {
        
    }

    void Update()
    {
        
        virusGainPerClick = umc.current_APC;
        virusMoney = umc.virusMoney;
        virusGainPerSec = umc.SucetAPS();
        virusMoneyText.text = System.Math.Round(virusMoney,1).ToString();
        apsText.text = "APS : " + System.Math.Round(umc.SucetAPS(),1).ToString();
        
    }

    public void VirusClick()
    {
        umc.AddMoney(virusGainPerClick); 
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Instantiate(virusPrefab, mousePosition, Quaternion.identity);
    }

    public IEnumerator VirusGainPerSec()
    {
            umc.AddMoney(virusGainPerSec);
            yield return new WaitForSeconds(1);
            StartCoroutine(VirusGainPerSec());
    }
   

    public void UpgradeMenuButton()
    {
        upgradeMenuPanel.SetActive(true);
        shadowPanel.SetActive(true);
    }

    public void CancelMenuButton()
    {
        upgradeMenuPanel.SetActive(false);
        shadowPanel.SetActive(false);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuController : MonoBehaviour
{
    public GameController gm;
    public float virusMoney;

    public Text ClickUpgradeInfo;
    public Text ClickUpgradePrice;
    public float current_APC = 1f;
    public float APC_multiplier = 0.4f;
    public float clickUpgradePrice = 25f;
    public float price_multiplier = 1.6f;
    /*nový riadok*/
    public Text FaceMaskInfo;
    public Text FaceMaskUpgradePrice;
    public bool faceMaskAquired = false;
    public float FMU_current_APS = 0.5f;
    private float FMU_APS_multiplier = 0.3f;
    private float faceMaskUpgradePrice = 180f;
    private float faceMaskPrice_multiplier = 2f;


    void Start()
    {
        ClickUpgradeInfo.text = "CURRENT APC : " + current_APC + "\n" + "NEW APC : " + (System.Math.Round((current_APC * APC_multiplier), 1) + current_APC).ToString();
        ClickUpgradePrice.text = clickUpgradePrice.ToString();

        FaceMaskInfo.text = "CURRENT APS : " + 0 + "\n" + "NEW APS : " + 0.5.ToString();
        FaceMaskUpgradePrice.text = "180";
    }

    
    void Update()
    {
        
    }

    public void AddMoney(float amount)
    {
        virusMoney += amount; 
    }

    public void ClickUpgrade()
    {
        if (virusMoney >= clickUpgradePrice)
        {
            virusMoney -= clickUpgradePrice;
            current_APC += (float)System.Math.Round((current_APC * APC_multiplier), 1);
            Debug.Log(current_APC);
            float new_APC = (float)System.Math.Round((current_APC * APC_multiplier), 1) + current_APC;
            clickUpgradePrice += (float)System.Math.Round((clickUpgradePrice * price_multiplier), 1);
            Debug.Log(clickUpgradePrice);

            ClickUpgradeInfo.text = "CURRENT APC : " + current_APC + "\n" + "NEW APC : " + new_APC.ToString();
            ClickUpgradePrice.text = clickUpgradePrice.ToString();
        }
        else
            Debug.Log("Neni dosť many");
    }

    public void FaceMaskUpgrade()
    {
        if (virusMoney >= faceMaskUpgradePrice)
        {
            

            if(faceMaskAquired == false)
            {
                Debug.Log("FaceMaskAquired");
                faceMaskAquired = true;
                virusMoney -= faceMaskUpgradePrice;
                FMU_current_APS = 0.5f;
                Debug.Log(FMU_current_APS);
                float new_APC = (float)System.Math.Round((FMU_current_APS * FMU_APS_multiplier), 1) + FMU_current_APS;
                faceMaskUpgradePrice += (float)System.Math.Round((faceMaskUpgradePrice * faceMaskPrice_multiplier), 1);
                Debug.Log(faceMaskUpgradePrice);

                FaceMaskInfo.text = "CURRENT APS : " + FMU_current_APS + "\n" + "NEW APS : " + new_APC.ToString();
                FaceMaskUpgradePrice.text = faceMaskUpgradePrice.ToString();
                StartCoroutine(gm.VirusGainPerSec());

            }
            else if (faceMaskAquired == true){
                virusMoney -= faceMaskUpgradePrice;
                FMU_current_APS += (float)System.Math.Round((FMU_current_APS * FMU_APS_multiplier), 1);
                Debug.Log(FMU_current_APS);
                float new_APC = (float)System.Math.Round((FMU_current_APS * FMU_APS_multiplier), 1) + FMU_current_APS;
                faceMaskUpgradePrice += (float)System.Math.Round((faceMaskUpgradePrice * faceMaskPrice_multiplier), 1);
                Debug.Log(faceMaskUpgradePrice);

                FaceMaskInfo.text = "CURRENT APS : " + FMU_current_APS + "\n" + "NEW APS : " + new_APC.ToString();
                FaceMaskUpgradePrice.text = faceMaskUpgradePrice.ToString();

            }

            
            
            
        }
        else
            Debug.Log("Neni dosť many");
    }
}

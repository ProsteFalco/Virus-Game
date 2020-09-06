using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuController : MonoBehaviour
{
    public GameController gm;
    public float virusMoney;
    public float APS = 0f;

    public Text ClickUpgradeInfo;
    public Text ClickUpgradePrice;
    public float current_APC = 1f;
    public float APC_multiplier = 0.4f;
    private int CU_lvl = 1;
    public float clickUpgradePrice = 25f;
    public float price_multiplier = 1.6f;
    
    public Text FaceMaskInfo;
    public Text FaceMaskUpgradePrice;
    public bool faceMaskAquired = false;
    private float FMU_current_APS = 0f;
    private float FMU_APS_multiplier = 1f;
    private int FMU_lvl = 0;
    private float faceMaskUpgradePrice = 180f;
    private float faceMaskPrice_multiplier = 0.9f;

    public Text HandWashingInfo;
    public Text HandWashingUpgradePrice;
    public bool handWashingAquired = false;
    private float HWU_current_APS = 0f;
    private float HWU_APS_multiplier = 1f;
    private int HWU_lvl = 0;
    private float handWashingUpgradePrice = 2000f;
    private float handWashingPrice_multiplier = 0.9f;


    void Start()
    {
        ClickUpgradeInfo.text = "CURRENT APC : " + current_APC + "\n" + "NEW APC : " + (System.Math.Round((current_APC * APC_multiplier), 1) + current_APC).ToString() + "\n" + "LEVEL : " + CU_lvl;
        ClickUpgradePrice.text = clickUpgradePrice.ToString();

        FaceMaskInfo.text = "CURRENT APS : " + 0 + "\n" + "NEW APS : " + 0.5.ToString() + "\n" + "LEVEL : " + FMU_lvl;
        FaceMaskUpgradePrice.text = "180";

        HandWashingInfo.text = "CURRENT APS : " + 0 + "\n" + "NEW APS : " + 4.ToString() + "\n" + "LEVEL : " + HWU_lvl;
        HandWashingUpgradePrice.text = "2000";
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
            CU_lvl++;
            ClickUpgradeInfo.text = "CURRENT APC : " + current_APC + "\n" + "NEW APC : " + new_APC.ToString() + "\n" + "LEVEL : " + CU_lvl;
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
                FMU_lvl++;
                FaceMaskInfo.text = "CURRENT APS : " + FMU_current_APS + "\n" + "NEW APS : " + new_APC.ToString() + "\n" + "LEVEL : " + FMU_lvl;
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
                FMU_lvl++;
                FaceMaskInfo.text = "CURRENT APS : " + FMU_current_APS + "\n" + "NEW APS : " + new_APC.ToString() + "\n" + "LEVEL : " + FMU_lvl;
                FaceMaskUpgradePrice.text = faceMaskUpgradePrice.ToString();

            }
            



        }
        else
            Debug.Log("Neni dosť many");
    }

    public void HandWashingUpgrade()
    {
        if (virusMoney >= handWashingUpgradePrice)
        {


            if (handWashingAquired == false)
            {
                Debug.Log("FaceMaskAquired");
                handWashingAquired = true;
                virusMoney -= handWashingUpgradePrice;
                HWU_current_APS = 4f;
                Debug.Log(HWU_current_APS);
                float new_APS = (float)System.Math.Round((HWU_current_APS * HWU_APS_multiplier), 1) + HWU_current_APS;
                handWashingUpgradePrice += (float)System.Math.Round((handWashingUpgradePrice * handWashingPrice_multiplier), 1);
                Debug.Log(handWashingUpgradePrice);
                HWU_lvl++;
                HandWashingInfo.text = "CURRENT APS : " + HWU_current_APS + "\n" + "NEW APS : " + new_APS.ToString() + "\n" + "LEVEL : " + HWU_lvl;
                HandWashingUpgradePrice.text = handWashingUpgradePrice.ToString();
                StartCoroutine(gm.VirusGainPerSec());

            }
            else if (handWashingAquired == true)
            {
                virusMoney -= handWashingUpgradePrice;
                HWU_current_APS += (float)System.Math.Round((HWU_current_APS * HWU_APS_multiplier), 1);
                Debug.Log(FMU_current_APS);
                float new_APS = (float)System.Math.Round((HWU_current_APS * HWU_APS_multiplier), 1) + HWU_current_APS;
                handWashingUpgradePrice += (float)System.Math.Round((handWashingUpgradePrice * handWashingPrice_multiplier), 1);
                Debug.Log(handWashingUpgradePrice);
                HWU_lvl++;
                HandWashingInfo.text = "CURRENT APS : " + HWU_current_APS + "\n" + "NEW APS : " + new_APS.ToString() + "\n" + "LEVEL : " + HWU_lvl;
                HandWashingUpgradePrice.text = handWashingUpgradePrice.ToString();

            }
            



        }
        else
            Debug.Log("Neni dosť many");
    }

    public float SucetAPS()
    {
        APS = HWU_current_APS + FMU_current_APS;
        return APS;
    }
}

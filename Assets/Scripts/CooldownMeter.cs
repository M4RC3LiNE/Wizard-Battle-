using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CooldownMeter : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject cooldownMeter;
    [SerializeField]public float cd;
    [System.NonSerialized]public float cdMax;
    private float cdStartingLength;
    GameObject visuals;

    public TextMeshProUGUI value;
    void Update()
    {
        if (cd > 0 && cdMax > 0)
        {
            value.text = cd.ToString("F2") + "/" + cdMax.ToString("F2");
        }
        else{
            value.text = "";
        }
        UpdateMeter (cooldownMeter, cd, cdMax, cdStartingLength);
        if (cd > 0 || Input.GetMouseButton(0))
        {
            visuals.SetActive(true);
        }
        else
        {
            visuals.SetActive(false);
        }
    }

    void UpdateMeter (GameObject meter, float amt, float maxAmt, float meterLength)
    {
        if (meter)
        {
            var width = meter.GetComponent<RectTransform>().sizeDelta;
            if (amt > 0)
            {
                meter.GetComponent<RectTransform>().sizeDelta = new Vector2((amt / maxAmt) * meterLength, width.y);
            }
        }
    }


    void Start()
    {
        cdStartingLength = cooldownMeter.GetComponent<RectTransform>().sizeDelta.x;
        visuals = transform.GetChild(0).gameObject;
    }

    

    public IEnumerator CooldownCounter()
    {
        var rate = 0.05;
        while (cd > 0)
        {
            cd -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class SetDataToText : MonoBehaviour
{
    [SerializeField] Toggle toggle;

    public TextMeshProUGUI leeftijdText;
    public TextMeshProUGUI lengteText;
    public TextMeshProUGUI gewichtText;
    public TextMeshProUGUI slaapText;
    public TextMeshProUGUI sportText;

    public GameObject ant;
    private DataReader data;

    // Start is called before the first frame update
    private void Awake()
    {
        data = ant.GetComponent<DataReader>();
    }

    public void Start()
    {
        toggle.isOn = false;
        setData(leeftijdText, lengteText, gewichtText, slaapText, sportText, data, 0);
    }

    private void Update()
    {
        
    }

    public void getWaterData()
    {
        if (toggle.isOn)
        {
            //meisje
            setData(leeftijdText, lengteText, gewichtText, slaapText, sportText, data, 1);
        } else
        {
            //jongen
            setData(leeftijdText, lengteText, gewichtText, slaapText, sportText, data, 2);
        }
    }

    public static void setData(TextMeshProUGUI leeftijdText, TextMeshProUGUI lengteText, TextMeshProUGUI gewichtText, TextMeshProUGUI slaapText, TextMeshProUGUI sportText, DataReader data, int dataType)
    {
        switch (dataType)
        {
            case 1:
                leeftijdText.SetText("Gemiddelde Leeftijd: " + data.averageAgeFemaleL.Average().ToString());
                lengteText.SetText("Gemiddelde Lengte: " + Mathf.Round(data.averageHeightFemaleL.Average()).ToString());
                //gewichtText.SetText("Gemiddelde Gewicht: " + data.averageWeightFemaleL.Average().ToString());
                slaapText.SetText("Slaap Kwaliteit: " + Mathf.Round(data.averageSleepQualityFemaleL.Average()).ToString());
                sportText.SetText("Sport Minuten: " + Mathf.Round(data.averageSportMinutesFemaleL.Average()).ToString());
                break;
            case 2:
                leeftijdText.SetText("Gemiddelde Leeftijd: " + data.averageAgeMaleL.Average().ToString());
                lengteText.SetText("Gemiddelde Lengte: " + Mathf.Round(data.averageHeightMaleL.Average()).ToString());
                //gewichtText.SetText("Gemiddelde Gewicht: " + data.averageWeightMaleL.Average().ToString());
                slaapText.SetText("Slaap Kwaliteit: " + Mathf.Round(data.averageSleepQualityMaleL.Average()).ToString());
                sportText.SetText("Sport Minuten: " + Mathf.Round(data.averageSportMinutesMaleL.Average()).ToString());
                break;
            default:
                leeftijdText.SetText("Gemiddelde Leeftijd: " + data.averageAgeL.Average().ToString());
                lengteText.SetText("Gemiddelde Lengte: " + Mathf.Round(data.averageHeightL.Average()).ToString());
                //gewichtText.SetText("Gemiddelde Gewicht: " + data.averageWeightL.Average().ToString());
                slaapText.SetText("Slaap Kwaliteit: " + Mathf.Round(data.averageSleepQualityL.Average()).ToString());
                sportText.SetText("Sport Minuten: " + Mathf.Round(data.averageSportMinutesL.Average()).ToString());
                break;
        }



    }
}

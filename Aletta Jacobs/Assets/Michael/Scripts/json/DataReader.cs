using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using UnityEngine;

public class DataReader : MonoBehaviour
{
    public TextAsset jsonFile;
    //private int[] averageAge;

    // Start is called before the first frame update
    void Start()
    {
        List<float> averageAgeL = new List<float>();
        List<float> averageAgeMaleL = new List<float>();
        List<float> averageAgeFemaleL = new List<float>();

        List<float> averageHeightL = new List<float>();
        List<float> averageHeightMaleL = new List<float>();
        List<float> averageHeightFemaleL = new List<float>();

        List<float> averageWeightL = new List<float>();
        List<float> averageWeightMaleL = new List<float>();
        List<float> averageWeightFemaleL = new List<float>();

        List<float> averageSleepQualityL = new List<float>();
        List<float> averageSleepQualityMaleL = new List<float>();
        List<float> averageSleepQualityFemaleL = new List<float>();

        List<float> averageSportMinutesL = new List<float>();
        List<float> averageSportMinutesMaleL = new List<float>();
        List<float> averageSportMinutesFemaleL = new List<float>();

        int amountOfMales = 0;
        int amountOfFemales = 0;

        People peopleInJson = JsonUtility.FromJson<People>(jsonFile.text);
        foreach (Person person in peopleInJson.DataPage)
        {
            //Debug.Log("Found person age:" + person.AGE + " Person's gender: " + person.GENDER);
            averageAgeL.Add(person.AGE);
            averageHeightL.Add(person.HEIGHT_T2);
            averageWeightL.Add(person.WEIGHT_T2);
            averageSportMinutesL.Add(person.SPORTS_T1);
            if (person.GENDER.Equals("1"))
            {
                averageAgeMaleL.Add(person.AGE);
                averageHeightMaleL.Add(person.HEIGHT_T2);
                averageWeightMaleL.Add(person.WEIGHT_T2);
                averageSportMinutesMaleL.Add(person.SPORTS_T1);
                amountOfMales++;
            }
            if (person.GENDER.Equals("2"))
            {
                averageAgeFemaleL.Add(person.AGE);
                averageHeightFemaleL.Add(person.HEIGHT_T2);
                averageWeightFemaleL.Add(person.WEIGHT_T2);
                averageSportMinutesFemaleL.Add(person.SPORTS_T1);
                amountOfFemales++;
            }
            if (!person.SLEEP_QUALITY.Equals(" "))
            {
                averageSleepQualityL.Add(person.SLEEP_QUALITY);
                if (person.GENDER.Equals("1")) { averageSleepQualityMaleL.Add(person.SLEEP_QUALITY); }
                if (person.GENDER.Equals("2")) { averageSleepQualityFemaleL.Add(person.SLEEP_QUALITY); }
            }
        }

        Debug.Log("Average age of people: " + averageAgeL.Average());
        Debug.Log("Average age of Male's: " + averageAgeMaleL.Average());
        Debug.Log("Average age of Female's: " + averageAgeFemaleL.Average());

        Debug.Log("Average Height: " + averageHeightL.Average());
        Debug.Log("Average Height of Male: " + averageHeightMaleL.Average());
        Debug.Log("Average Height of Female: " + averageHeightFemaleL.Average());

        Debug.Log("\nIn total there are: " + amountOfMales + " males, and: " + amountOfFemales + " females.");
        string text = File.ReadAllText(@"./assets/data.json");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

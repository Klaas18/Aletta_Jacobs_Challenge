using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JSONReader : MonoBehaviour
{
    [Header("Data")]
    public TextAsset textJSON;
    [SerializeField] private TextMeshProUGUI text;
   public List<int> heightList = new List<int>();

    [System.Serializable]
    public class Value
    {
        public string Name;
        public int Height;
        public int Width;
        public int Weight;
    }

    [System.Serializable]
    public class ValueList
    {
        public Value[] Value;
    }

    public ValueList myValueList = new ValueList();
  
    void Start()
    {
        myValueList = JsonUtility.FromJson<ValueList>(textJSON.text);

        foreach (var a in myValueList.Value)
        {
            text.text += "Height ="+a.Height+"\n";
            heightList.Add(a.Height);
        }
        heightList.Sort();
   
    }
}

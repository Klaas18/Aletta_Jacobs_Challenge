using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class JSONReader : MonoBehaviour
{
    [Header("Data")]
    public TextAsset textJSON;
    public static TextAsset s_textJSON;
    [SerializeField] private static TextMeshProUGUI text;
    public static List<int> heightList = new List<int>();

    public void Awake()
    {
        s_textJSON = textJSON;

        myValueList = JsonUtility.FromJson<ValueList>(s_textJSON.text);

        foreach (var a in myValueList.Value)
        {
        //    text.text += "Height =" + a.Height + "\n";
          heightList.Add(a.Height);
        }
       // heightList.Sort();
    }

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

    public static ValueList myValueList = new ValueList();

    static void Start()
    {
        //myValueList = JsonUtility.FromJson<ValueList>(s_textJSON.text);

        //foreach (var a in myValueList.Value)
        //{
        //    text.text += "Height =" + a.Height + "\n";
        //    heightList.Add(a.Height);
        //}
        //heightList.Sort();

    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DisplayTestData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = string.Concat( "Float: ", DataHolder.modifierFloat, System.Environment.NewLine, "String: ", DataHolder.modifierString );
    }
}

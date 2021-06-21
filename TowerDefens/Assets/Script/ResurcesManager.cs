using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResurcesManager : MonoBehaviour
{
    public Text StoneTxt;
    public int StoneCount;
  
    void Start()
    {
        StoneCount = 50;
       
    }

    void Update()
    {
        StoneTxt.text = "Gold:" + StoneCount;
    }
}

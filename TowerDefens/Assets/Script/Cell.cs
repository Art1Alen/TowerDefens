using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Material MainMaterial;
    public Material OverMaterial;
    public GameObject TowerPrafab;
    public int BildCost;

    public bool CanBild;

    private ResurcesManager resource;

   

    void Start()
    {
        resource = FindObjectOfType<ResurcesManager>();
    }
    private void OnMouseUp()
    {
        if (CanBild && resource.StoneCount >= BildCost)
        {
            Instantiate(TowerPrafab, transform.position, Quaternion.Euler(0, Random.Range(0, 360),0));
            CanBild = false;
            resource.StoneCount -= BildCost;
        }
    }
    private void OnMouseOver()
    {
        if(CanBild) 
        GetComponent<Renderer>().material = OverMaterial;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = MainMaterial;
    }
}

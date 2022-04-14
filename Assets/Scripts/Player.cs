using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int pickups;
    public TextMeshProUGUI pickupTextMesh;
    public int Pickups { get; set; }
    void Start()
    {
        
    }
    public void PickUp()
    {
        pickups++;
        pickupTextMesh.text = "PowerUps: " + pickups;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Tekst:" + pickupTextMesh.text);
    }
}

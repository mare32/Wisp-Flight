using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElements : MonoBehaviour
{
    [SerializeField]
    public Player playerReference;

    [SerializeField]
    public GameObject mainCameraReference;

    void Awake ()
    {
        //TODO implement better refererncing
        if (playerReference == null)
            playerReference = this.transform.Find("Player").GetComponent<Player>();


        if (mainCameraReference == null)
            mainCameraReference = this.transform.Find("Main Camera").gameObject;
    }
}

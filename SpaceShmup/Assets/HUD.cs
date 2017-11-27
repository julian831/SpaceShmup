using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    //creates an array of sprites
    public Sprite[] ShipSprites;

    public Image ShipUI;

    private Hero hero;

    void Start()
    {

        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
    }

    void Update()
    {
        ShipUI.sprite = ShipSprites[hero.lives];
    }
}

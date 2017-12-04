using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hero : MonoBehaviour
{
    static public Hero S;

    public float gameRestartDelay = 2f;

    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    public Text gameOverText;
    public GameObject gameOverPanel; 

    //Player lives
    public int lives = 3;

    // Ship status information
    [SerializeField]
    private float _shieldLevel = 1; // Add the underscore!
    // Weapon fields
    public Weapon[] weapons;

    public bool _____________________;
    public Bounds bounds;

    // Declare a new delegate type WeaponFireDelegate
    public delegate void WeaponFireDelegate();
    // Create a WeaponFireDelegate field named fireDelegate.
    public WeaponFireDelegate fireDelegate;

    public GameObject gameOverPanel;
    public Text gameOverText;
    
    void Awake()
    {
       S = this;
       bounds = Utils.CombineBoundsOfChildren(this.gameObject);
        gameOverPanel.SetActive(false);
   }

    // Use this for initialization
    void Start()
    {
        // Reset the weapons to start _Hero with 1 blaster
        ClearWeapons();
        weapons[0].SetType(WeaponType.blaster);
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        bounds.center = transform.position;

        // constrain to screen
        Vector3 off = Utils.ScreenBoundsCheck(bounds, BoundsTest.onScreen);
        if (off != Vector3.zero)
        {  // we need to move ship back on screen
            pos -= off;
            transform.position = pos;
        }

        // rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
        // Use the fireDelegate to fire Weapons
        // First, make sure the Axis("Jump") button is pressed
        // Then ensure that fireDelegate isn't null to avoid an error
        if (Input.GetAxis("Jump") == 1 && fireDelegate != null)
        { // 1
            fireDelegate();
        }
    }
    // This variable holds a reference to the last triggering GameObject
    public GameObject lastTriggerGo = null;

   
    void OnTriggerEnter(Collider other)
    {
        // Find the tag of other.gameObject or its parent GameObjects
        GameObject go = Utils.FindTaggedParent(other.gameObject);
        // If there is a parent with a tag
        if (go != null)
        {
            print("Triggered: " + go.name);
            // Make sure it's not the same triggering go as last time
            if (go == lastTriggerGo)
            { // 2
                return;
            }
            lastTriggerGo = go; // 3
            if (go.tag == "Enemy")
            {
                // If the shield was triggered by an enemy
                // Decrease the level of the shield by 1
                shieldLevel--;
                // Destroy the enemy
                Destroy(go); // 4
            }
            else if (go.tag == "PowerUp")
            {
                // If the shield was triggerd by a PowerUp
                AbsorbPowerUp(go);
            }
            else
            {
                print("Triggered: " + go.name); // Move this line here!
            }
        }
    }

    public void AbsorbPowerUp(GameObject go)
    {
        PowerUp pu = go.GetComponent<PowerUp>();
        switch (pu.type)
        {
            case WeaponType.shield: // If it's the shield
                shieldLevel++;
                break;
            default: // If it's any Weapon PowerUp
                     // Check the current weapon type
                if (pu.type == weapons[0].type)
                {
                    // then increase the number of weapons of this type
                    Weapon w = GetEmptyWeaponSlot(); // Find an available weapon
                    if (w != null)
                    {
                        // Set it to pu.type
                        w.SetType(pu.type);
                    }
                }
                else
                {
                    // If this is a different weapon
                    ClearWeapons();
                    weapons[0].SetType(pu.type);
                }
                break;
        }
        pu.AbsorbedBy(this.gameObject);
    }
    Weapon GetEmptyWeaponSlot()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].type == WeaponType.none)
            {
                return (weapons[i]);
            }
        }
        return (null);
    }
    void ClearWeapons()
    {
        foreach (Weapon w in weapons)
        {
            w.SetType(WeaponType.none);
        }
    }

    void DisableText()
    {
        gameOverText.enabled = false;
    }

public float shieldLevel
    {
        get
        {
            return (_shieldLevel); // 1
        }
        set
        {
            _shieldLevel = Mathf.Min(value, 4); // 2
            // If the shield is going to be set to less than zero
            if (value < 0)
            {
                //resets hero ship location back to zero
          
                transform.position = Vector3.zero;

                //subtracts a life from player hero 
                lives -= 1;

                if (lives > 0)
                {
                   // Awake();
                }

                else if (lives == 0)
                {
                    
                    Destroy(this.gameObject);
                    gameOverPanel.SetActive(true);
                    gameOverText.text = "GAME OVER";
                    //Tell Main.S to restart the game after a delay
<<<<<<< HEAD
                    Main.S.DelayedRestart(gameRestartDelay);
=======
                   
                   
                    Destroy(this.gameObject);
                    gameOverPanel.SetActive(true);
                    gameOverText.text = "GAME OVER";
                    Main.S.DelayedRestart(gameRestartDelay);

>>>>>>> b701d910d587c70609a2dce32a632cdd53060868
                }


            }
        }
    }

}
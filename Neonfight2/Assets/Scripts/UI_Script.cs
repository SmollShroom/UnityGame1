using UnityEngine;

public class UI_Script : MonoBehaviour
{

    public GameObject WeaponHandler;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<Text>().text = "Resources: " + WeaponHandler.GetComponent<weaponController>().Resources.ToString("F0") + " / " + WeaponHandler.GetComponent<weaponController>().RecourcesMax.ToString("F0");
        GetComponent<UnityEngine.UI.Text>().text = "Resource : " + WeaponHandler.GetComponent<weaponController>().Resources.ToString("F0");
    }
}

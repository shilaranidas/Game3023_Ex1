using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPos : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            float px = player.transform.position.x;
            float py = player.transform.position.y;
            float pz = player.transform.position.z;
            px = PlayerPrefs.GetFloat("p_x");
            py = PlayerPrefs.GetFloat("p_y");
            pz = PlayerPrefs.GetFloat("p_z");
            Debug.Log("player position loaded");
            player.transform.position = new Vector3(px, py, pz);
            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
        }
    }
    public void PlayerPosSave()
    {
        PlayerPrefs.SetFloat("p_x", player.transform.position.x);
        PlayerPrefs.SetFloat("p_y", player.transform.position.y);
        PlayerPrefs.SetFloat("p_z", player.transform.position.z);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
        Debug.Log("player position saved!");
    }
    public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Upgrade : MonoBehaviour
{
    public playerMove playerMove;
    public Text maxhealthText;
    public Text maxArmorText;
    public Text shootText;
    GameManager GameManager;
    int i = 0;
    int n = 0;
    int z = 0;
    public float healthupgradecost = 2;
    public float shootupgradecost = 2;
    public float armorupgradecost
        =2;
    public void Start()
    {
        i = PlayerPrefs.GetInt("i");
        z = PlayerPrefs.GetInt("z");
        n = PlayerPrefs.GetInt("n");
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        maxArmorText.text ="Armor " + playerMove.Maxarmor.ToString();
        maxhealthText.text ="Health " + playerMove.Maxhealth.ToString();
        shootText.text ="Damage " + playerMove.damage.ToString();
       healthupgradecost = PlayerPrefs.GetFloat("healthupgradecost", 2);
        armorupgradecost = PlayerPrefs.GetFloat("armorupgradecost", 2);
        shootupgradecost = PlayerPrefs.GetFloat("shootupgradecost" , 2);
    }
    private void FixedUpdate()
    {
        maxArmorText.text = "Armor  " + playerMove.Maxarmor.ToString();
        maxhealthText.text = "Health  " + playerMove.Maxhealth.ToString();
        shootText.text = "Damage  " + playerMove.damage.ToString();
    }
    public void healthUpgrade()
    {
        while(GameManager.money >= healthupgradecost && i <= 8)
        {
                playerMove.Maxhealth += 50;
                GameManager.money -= healthupgradecost;
                healthupgradecost = healthupgradecost * 2;
                PlayerPrefs.SetFloat("healthupgradecost", healthupgradecost);
                PlayerPrefs.SetFloat("MaxHealth", playerMove.Maxhealth);
            PlayerPrefs.SetFloat("money", GameManager.money);
            i++;
            PlayerPrefs.SetInt("i", i);
        }
    }
    public void ArmorUpgrade()
    {
        if(GameManager.money >= armorupgradecost && n <= 8)
        {
                playerMove.Maxarmor += 50;
                GameManager.money -= armorupgradecost;
                armorupgradecost = armorupgradecost * 2;
                PlayerPrefs.SetFloat("armorupgradecost", armorupgradecost);
                PlayerPrefs.SetFloat("ArmorHelath", playerMove.Maxarmor);
            PlayerPrefs.SetFloat("money", GameManager.money);
            n++;
            PlayerPrefs.SetInt("n", n);
        }
    }
    public void ShootUpgrade()
    {
        if(GameManager.money >= shootupgradecost && n <= 8)
        {
                playerMove.damage += 20;
                GameManager.money -= shootupgradecost;
            shootupgradecost = shootupgradecost * 2;
                PlayerPrefs.SetFloat("shootupgradecost", shootupgradecost);
                PlayerPrefs.SetFloat("damage", playerMove.damage);
            PlayerPrefs.SetFloat("money", GameManager.money);
            z++;
            PlayerPrefs.SetInt("z", z);
        }
    }
}

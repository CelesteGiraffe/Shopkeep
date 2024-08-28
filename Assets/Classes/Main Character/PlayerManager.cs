using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int money = 100;
    TextMeshProUGUI goldText;

    public void AddMoney(int amount)
    {
        money += amount;
        SetMoneyText(goldText);
    }
    private void Awake()
    {
        //find the game object named Gold
        goldText = GameObject.Find("Gold").GetComponent<TextMeshProUGUI>();
        SetMoneyText(goldText);
    }

    public bool SubtractMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            SetMoneyText(goldText);
            return true;
        }
        return false;
    }

    //set the text of a text mesh pro object with the money value
    public void SetMoneyText(TextMeshProUGUI moneyText)
    {
        moneyText.text = "£ " + money.ToString();
    }
}
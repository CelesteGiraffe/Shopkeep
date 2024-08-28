using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int money = 100; 

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public bool SubtractMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            return true;
        }
        return false;
    }
}
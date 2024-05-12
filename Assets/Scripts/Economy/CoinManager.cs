using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int Coins => _currentCoins;

    private int _currentCoins = 9999;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);
    }

    public void AddCoins(int amount)
    {
        _currentCoins += amount;
    }

    public bool DiscountCoins(int amount)
    {
        if (amount > _currentCoins) return false;

        _currentCoins -= amount;

        return true;
    }
}

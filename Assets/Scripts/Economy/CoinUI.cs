using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _coinText;

    private void Start()
    {
        if (CoinManager.Instance)
        {
            CoinManager.Instance.OnUpdateCoins += UpdateUI;

            UpdateUI(CoinManager.Instance.Coins);

            return;
        }

        UpdateUI(0);
    }

    public void UpdateUI(int coinAmount)
    {
        _coinText.text = coinAmount.ToString();
    }
}
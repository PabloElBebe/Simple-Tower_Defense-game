using TMPro;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public static MoneyController Instance;

    [SerializeField] private TextMeshProUGUI _moneyTMP;
    
    private MoneyVisualizer _moneyVisualizer;
    private MoneyCounter _moneyCounter;

    public void Awake()
    {
        Instance = this;
        _moneyVisualizer = new MoneyVisualizer(_moneyTMP);
        _moneyCounter = new MoneyCounter(_moneyVisualizer);
    }

    private void Start()
    {
        IncreaseMoney(1000);
    }

    public void DecreaseMoney(int amount)
    {
        if (amount < 0)
            return;
        
        _moneyCounter.DecreaseMoney(amount);
    }

    public void IncreaseMoney(int amount)
    {
        if (amount < 0)
            return;

        _moneyCounter.IncreaseMoney(amount);
    }

    public int GetMoneyAmount()
    {
        return _moneyCounter.Money;
    }
}

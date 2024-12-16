public class MoneyCounter
{
    private MoneyVisualizer _moneyVisualizer;
    private int _money;
    public int Money => _money;

    public MoneyCounter(MoneyVisualizer moneyVisualizer)
    {
        _moneyVisualizer = moneyVisualizer;
    }
    
    public void DecreaseMoney(int amount)
    {
        if (amount < 0)
            return;
        
        _money -= amount;

        if (_money < 0)
            _money = 0;
        
        _moneyVisualizer.ReloadText('$' + _money.ToString());
    }

    public void IncreaseMoney(int amount)
    {
        if (amount < 0)
            return;
        
        _money += amount;
        
        _moneyVisualizer.ReloadText('$' + _money.ToString());
    }
}

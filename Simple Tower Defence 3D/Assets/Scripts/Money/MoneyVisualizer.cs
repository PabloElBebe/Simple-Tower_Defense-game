using TMPro;

public class MoneyVisualizer
{
    private TextMeshProUGUI _moneyTMP;

    public MoneyVisualizer(TextMeshProUGUI moneyTMP)
    {
        _moneyTMP = moneyTMP;
    }
    
    public void ReloadText(string text)
    {
        _moneyTMP.text = text;
    }
}

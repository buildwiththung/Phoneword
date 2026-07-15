namespace Phoneword;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        
    }

    public void OnTranslate()
    {
        string raw = PhoneNumberText.Text;
        if (!string.IsNullOrWhiteSpace(raw))
        {
            string result = PhonewordTranslator.ReceiveRaw(raw);
        }
        else
        {
            return;
        }
    }
    
}
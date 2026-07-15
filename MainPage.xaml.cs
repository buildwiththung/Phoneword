namespace Phoneword;

public partial class MainPage : ContentPage
{
    string result = string.Empty;

    public MainPage()
    {
        InitializeComponent();
    }
    
    private void OnTranslate(object sender, EventArgs e)
    {
        string raw = PhoneNumberText.Text;
        if (!string.IsNullOrEmpty(raw))
        {
            result = PhonewordTranslator.ReceiveRaw(raw);
            
            CallButton.IsEnabled = true;
            CallButton.Text = "Call " + result;
        }
        else
        {
            CallButton.IsEnabled = false;
            CallButton.Text = "Call";
        }
    }
    
    async void OnCall(object sender, System.EventArgs e)
    {
        if (await this.DisplayAlertAsync(
                "Dial a Number",
                "Would you like to call " + result + "?",
                "Yes",
                "No"))
        {
            try
            {
                if (PhoneDialer.Default.IsSupported && !string.IsNullOrWhiteSpace(result))
                {
                    PhoneDialer.Default.Open(result);
                }
            }
            catch (ArgumentNullException)
            {
                await DisplayAlertAsync("Unable to dial", "Phone number was not valid.", "OK");
            }
            catch (Exception)
            {
                // Xử lý các lỗi phát sinh khác ngoài dự kiến
                await DisplayAlertAsync("Unable to dial", "Phone dialing failed.", "OK");
            }
        }
    }
}
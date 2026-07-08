using System.Text;

namespace Phoneword;
public class PhonewordTranslator
{
    public static string? ToNumber(string raw) /*tạo 1 hàm public tĩnh tar về string or null để bên UI gọi, truyền vào đó tham số string tên raw*/
    {
        if (string.IsNullOrWhiteSpace(raw)) /*check null then return null*/
            return null;
        raw = raw.ToUpperInvariant(); /* nếu raw không null và không rỗng thì gán giá trị UI truyền về vô raw và viết hoa hết*/
        var newNumber = new StringBuilder(); /*tạo 1 biến newNumber gắn dô cái hộp nối kí tự StringBuilder*/
        foreach (var c in raw) /*loop qua mỗi kí tự c trong dãy raw*/
        {
            if(" -0123456789".Contains(c)) /*nếu các kí tự space-123456789*Contains(c) chứa chuỗi c*/
            {
                newNumber.Append(c); /*thì gắn c đó dô newNumber (nằm trog cái hộp StringBuilder)*/
            }
            else /*nếu k nằm trog đống space-123456789* thì: */
            {
                var result = TranslateToNumber(c);  /*tạo 1 biến result gắn vô hàm tự viết TranslateToNumber*/
                if (result != null) /*nếu result khác null */
                {
                    newNumber.Append(result); /*thì result(đã được chuyển đổi) gắn dô newNumber (nằm trog cái hộp StringBuilder)*/
                }
                else 
                {
                    return null; /*còn nếu result = null thì stop*/ 
                }
            }
        }
        return newNumber.ToString(); /*trả về cho hàm ToNumber newNumber đã chuyển thành string*/
    }

    private static bool Contains(string keyString, char c) /*1 hàm private tĩnh trả về tham số true false , truyền dô name keyString, giá trị string & name c , goá trị char*/
    {
        return keyString.IndexOf(c) >= 0; /*check vị trí c trong chuỗi keyString , so sánh vị trí đó với 0, >= 0 nghĩa là tìm thấy, < 0 nghĩa là không tìm thấy*/
    }

    private static readonly string[] digits = { /*biến read only nhận vào name digits giá trị 1 mảng string ở dưới */
        "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
    };
    
    private static int? TranslateToNumber(char c) /*hàm TranslateToNumber trả về giá trị int , nhận vào name c giá trị char*/
    {
        for (int i = 0; i < digits.Length; i++) /*i chạy từ 0 tới hết chiều dài của digits, mỗi vòng + 1*/
        {
            if (digits[i].Contains(c)) /*nếu giá trị của  vị trí i của mảng digits giống với kí tự c*/
            {
                return i+2 ; /*thì vị trí i + 2*/ 
            }
        }
        return null;
    }
}


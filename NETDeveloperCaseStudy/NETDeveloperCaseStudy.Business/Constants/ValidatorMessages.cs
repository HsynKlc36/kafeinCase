namespace NETDeveloperCaseStudy.Business.Constants;

/// <summary>
/// Validator Mesajları burada tutulacak!Yani apiden gelen dataları kontrol ettiğimiz validation mesajları burada tutulacak ve hatalı datalarda buradaki mesajlar dönecek!ayrıca resource.resx dosyalarında tutularak geri dönen response 'un dil seçeneğine uygun validasyonlar dönecektir.
/// </summary>
public class ValidatorMessages
{
    public const string AddressNotNull = "Address_Not_Null";
    public const string AddressLength = "Address_Length";
    public const string AddressNoSpecialChars = "Address_No_Special_Chars";

    public const string ClientActiveIdNotEmpty = "Client_Active_Id_Not_Empty";
    public const string ClientActionTypeNotEmpty = "Client_Action_Type_Not_Empty";
    public const string ClientActiveDescriptionNotNull = "Client_Active_Description_Not_Null";
    public const string ClientActiveDescriptionNotEmpty = "Client_Active_Description_Not_Empty";
    public const string ClientActiveDescriptionMinLength = "Client_Active_Description_Min_Length";
    public const string ClientActiveDescriptionMaxLength = "Client_Active_Description_Max_Length";
    public const string ClientFirstNameNotEmpty = "Client_FirstName_Not_Empty";
    public const string ClientFirstNameMinLength = "Client_FirstName_Min_Length";
    public const string ClientFirstNameMaxLength = "Client_FirstName_Max_Length";
    public const string ClientFirstNameMatches = "Client_FirstName_Matches";
    public const string ClientLastNameNotEmpty = "Client_LastName_Not_Empty";
    public const string ClientLastNameMinLength = "Client_LastName_Min_Length";
    public const string ClientLastNameMaxLength = "Client_LastName_Max_Length";
    public const string ClientLastNameMatches = "Client_LastName_Matches";
    public const string ClientEmailNotEmpty = "Client_Email_Not_Empty";
    public const string ClientEmailControl = "Client_Email_Control";
    public const string ClientDateOfBirthControl = "Client_Date_Of_Birth_Control";
    public const string ClientAddressNotNull = "Client_Address_Not_Null";
    public const string ClientAddressLength = "Client_Address_Length";
    public const string ClientAddressNoSpecialChars = "Client_Address_No_Special_Chars";
    public const string ClientIdDoNotNullOrEmpty = "ClientId_Do_Not_Null_Or_Empty";

    public const string AmountGreaterThan = "Amount_GreaterThan";
    public const string AmountControl = "Amount_Control";

    public const string ProductIdNotNullOrEmpty = "ProductId_Do_Not_Null_Or_Empty";
    public const string MarketIdNotNullOrEmpty = "MarketId_Do_Not_Null_Or_Empty";
    public const string CustomerIdNotNullOrEmpty = "CustomerId_Do_Not_Null_Or_Empty";
    public const string CustomerIdControl = "CustomerId_Control";
    public const string MarketIdControl = "MarketId_Control";
    public const string ProductIdControl = "ProductId_Control";

    public const string DateOfBirthControl = "Date_Of_Birth_Control";

    public const string EmailNotEmpty = "Email_Not_Empty";
    public const string EmailControl = "Email_Control";

    public const string GenderNotEmpty = "Gender_Not_Empty";

    public const string FirstNameNotEmpty = "FirstName_Not_Empty";
    public const string FirstNameMinLength = "FirstName_Min_Length";
    public const string FirstNameMaxLength = "FirstName_Max_Length";
    public const string FirstNameMatches = "FirstName_Matches";

    public const string ImageNotEmpty = "Image_Not_Empty";
    public const string ImageExtension = "Image_Extension";
    public const string ImageFileSize = "Image_File_Size";
    public const string IdDoNotNullOrEmpty = "Id_Do_Not_Null_Or_Empty";
    public const string IsClientControl = "IsClient_Control";

    public const string LastNameNotEmpty = "LastName_Not_Empty";
    public const string LastNameMinLength = "LastName_Min_Length";
    public const string LastNameMaxLength = "LastName_Max_Length";
    public const string LastNameMatches = "LastName_Matches";
    public const string LoginEmailNotEmpty = "Login_Email_Not_Empty";
    public const string LoginEmailControl = "Login_Email_Control";
    public const string LoginPasswordControl = "Password_Must_Be_At_Least_8_Characters_Long_And_Contain_At_Least_One_Uppercase_Letter_One_Lowercase_Letter_And_One_Digit";
    public const string LoginPasswordNotEmpty = "Login_Password_Not_Empty";

    public const string PhoneNumberNotEmpty = "Phone_Number_Not_Empty";
    public const string PhoneNumberMatches = "Phone_Number_Matches";
    public const string PhoneNumberLength = "Phone_Number_Length";

    public const string RoleAssignSuccess = "Role_Assignment_Success";
    public const string RoleAssignFailed = "Role_Assignment_Fail";

    public const string UserEmailNotEmpty = "User_Email_Not_Empty";
    public const string UserEmailControl = "User_Email_Control";



}

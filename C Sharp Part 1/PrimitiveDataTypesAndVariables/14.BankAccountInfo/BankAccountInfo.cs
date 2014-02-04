using System;

class BankAccountInfo
{
    static void Main()
    {
        string firstName = "Stoyan";
        string middleName = "Stefkov";
        string lastName = "Stoyanov";
        decimal bankAccountBalance = 1452.34m;
        string bankName = "FIBank";
        string iban = "BG33FINV12311012345678";
        string bicCode = "FINVBGSF";
        ulong creditCardNumber1 = 3281329889345327;
        ulong creditCardNumber2 = 8217874127838721;
        ulong creditCardNumber3 = 6874321357733231;

        Console.WriteLine("Name: {0} {1} {2}",firstName,middleName,lastName);
        Console.WriteLine("Bank name: {0}   BIC/SWIFT Code:   {1} IBAN: {2}",bankName,bicCode,iban );
        Console.WriteLine("Bank account balance: {0:C2}",bankAccountBalance);
        Console.WriteLine("List of credit card numbers: \n {0} \n {1} \n {2}\n",creditCardNumber1,creditCardNumber2,creditCardNumber3);
    }
}


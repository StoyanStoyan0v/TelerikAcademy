using System;
using System.Text;

class EncryptionKey
{
    static string EqualKeyToText(string text, string key)
    {
        StringBuilder extendKey = new StringBuilder(key);

        if(key.Length<text.Length)
        {            
            for (int i = 0; i < text.Length-key.Length; i++)
            {
                extendKey.Append(key[i]);
            }
        }
        return extendKey.ToString();
    }

    static string EncodeDecodeText(string text, string key)
    {
        StringBuilder encoded = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            encoded.Append((char)(text[i] ^ key[i]));
        }
        return encoded.ToString();
    }


    static void Main()
    {
        Console.Write("Initial text: ");
        string text = Console.ReadLine();
        Console.Write("Encryption key: ");
        string key = Console.ReadLine();
        key = EqualKeyToText(text,key);
        string encodedText = EncodeDecodeText(text, key);
        Console.WriteLine("Encoded text: "+ encodedText);
        string decodedText = EncodeDecodeText(encodedText, key);
        Console.WriteLine("Decoded text again: "+decodedText);       
    }
}


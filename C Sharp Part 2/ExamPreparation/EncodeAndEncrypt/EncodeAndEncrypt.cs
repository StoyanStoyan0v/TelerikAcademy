using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EncodeAndEncrypt
{
    static string Encrypt (string message,string cypher)
    {
        string result = string.Empty;

        if(message.Length>cypher.Length)
        {
            result=EncryptWhenMessageIsLOnger(message, cypher);
        }
        else
        {
            result = EncryptWhenCypherIsLonger(message, cypher);
        }

        return result.ToString();
    }

    static string EncryptWhenCypherIsLonger(string message, string cypher)
    {
        StringBuilder result = new StringBuilder(message);

        int messageIndex = 0;

        for (int i = 0; i < cypher.Length; i++)
        {
            char messageSymbol = result[messageIndex];
            char cypherSymbol = cypher[i];
            char encryptedSymbol = EncryptSymbol(messageSymbol, cypherSymbol);

            result[messageIndex] = encryptedSymbol;

            messageIndex++;

            if (messageIndex == message.Length)
            {
                messageIndex = 0;
            }
        }

        return result.ToString();
    }

    static string EncryptWhenMessageIsLOnger(string message, string cypher)
    {
        StringBuilder result = new StringBuilder();

        int cypherIndex = 0;

        for (int i = 0; i < message.Length; i++)
        {
            char messageSymbol=message[i];
            char cyherSymbol = cypher[cypherIndex];
            char encryptedSymbol = EncryptSymbol(messageSymbol, cyherSymbol);
            result.Append(encryptedSymbol);
            cypherIndex++;
            
            if(cypherIndex==cypher.Length)
            {
                cypherIndex = 0;
            }
        }

        return result.ToString();
    }

    static char EncryptSymbol(char messageSymbol, char cypherSymbol)
    {
        int messageSymbolCode = messageSymbol - 'A';
        int cypherSymbolCode = cypherSymbol - 'A';

        int xoredSymbol = messageSymbolCode ^ cypherSymbolCode;
        char result = (char)(xoredSymbol + 'A');
        return result;
        
    }

    static string  Encode(string text)
    {
        StringBuilder result = new StringBuilder();

        int counter = 1;
        char previousSymbol = text[0];

        for (int i = 1; i < text.Length; i++)
        {
            if(text[i]==previousSymbol)
            {
                counter++;
            }
            else
            {
                if(counter==1)
                {
                    result.Append(previousSymbol);
                }
                else if(counter==2)
                {
                    result.Append(new string(previousSymbol, 2));
                }
                else
                {
                    result.Append(counter + previousSymbol.ToString());
                }
                counter = 1;
            }            
            previousSymbol = text[i];
        }
        if (counter == 1)
        {
            result.Append(previousSymbol);
        }
        else if (counter == 2)
        {
            result.Append(new string(previousSymbol, 2));
        }
        else
        {
            result.Append(counter + previousSymbol.ToString());
        }

        return result.ToString();
    }

    static void Main()
    {
        string message = Console.ReadLine();
        string cypher = Console.ReadLine();

        int length = cypher.Length;

        string finalResult = Encode(Encrypt(message, cypher) + cypher) + cypher.Length;
        Console.WriteLine(finalResult);
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MessageInABottle
{
    class MessageInABottle
    {
        static  List<string> allMessages = new List<string>();
        static Dictionary<char, string > cipherItems = new Dictionary<char, string>();
        static void GetCipherItems(string cipher)
        {
            StringBuilder currenCipher = new StringBuilder();
            char lastChar = ' ';
            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] >= 'A' && cipher[i] <= 'Z')
                {
                    if (currenCipher.Length > 0)
                    {
                        
                        cipherItems.Add(lastChar,currenCipher.ToString());
                        currenCipher.Clear();

                    }
                    lastChar = cipher[i];
                }
                else
                {
                    currenCipher.Append(cipher[i]);
                }
            }
            cipherItems.Add(lastChar, currenCipher.ToString());
        }

        static void GetMessages(char[] message,  int index, string secretMessage, int wordIndex)
        {
            if (index == secretMessage.Length)
            {
                GetAllMessages(message,secretMessage);
                return;
            }
            if (index > secretMessage.Length)
            {
                return;
            }
            foreach (var item in cipherItems)
            {
                if (secretMessage.Length >= index + item.Value.Length && secretMessage.Substring(index, item.Value.Length) == item.Value)
                {
                    message[wordIndex] = item.Key;
                    GetMessages(message,index + item.Value.Length,secretMessage, wordIndex + 1);
                    message[wordIndex] = '\0';
                }
            }
        }

        static void GetAllMessages(char[]currentCipher, string secretMessage)
        {
            StringBuilder originalMessage = new StringBuilder();
            for (int i = 0; i < currentCipher.Length; i++)
            {                                
                if (currentCipher[i] < 'A' || currentCipher[i] > 'Z')
                {
                    break;
                }
                originalMessage.Append(currentCipher[i]);               
            }
            allMessages.Add(originalMessage.ToString());
        }

        static void Main(string[] args)
        {
            string secretMessage = Console.ReadLine();
            string cipher = Console.ReadLine();
            
            GetCipherItems(cipher);

            char[] messages = new char[100];

            GetMessages(messages, 0,secretMessage, 0);
            Console.WriteLine(allMessages.Count);
            allMessages.Sort();
            foreach (string message in allMessages)
            {
                Console.WriteLine(message);
            }
        }       
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_fundamentals.ConsoleApp.TrainingApp.Password_Manager
{
    public static class Encryption
    {
        public static string Encrypter(string Originalpassword)
        {
            string EncryptedPassword = "";
            const string DecryptedText = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            const string EncryptedText = "F2bDFi4YVQu7TUxhmfsq6tkXWl10ZNy9BnSAPIvjgKw3CrzReLEdJ5ca08MGop";
            int index;
            for (int i = 0;i<Originalpassword.Length;i++)
            {
                index = DecryptedText.IndexOf(Originalpassword[i]);
                EncryptedPassword += EncryptedText[index];
            }

            return EncryptedPassword;
        }

        public static string Decrypter(string EncryptedPassword)
        {
            string DecryptedPassword = "";
            const string DecryptedText = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            const string EncryptedText = "F2bDFi4YVQu7TUxhmfsq6tkXWl1OZNy9BnSAPIvjgKw3CrzReLEdJ5ca08MGop";
            int index;
            for (int i = 0; i < EncryptedPassword.Length; i++)
            {
                index = EncryptedText.IndexOf(EncryptedPassword[i]);
                DecryptedPassword += DecryptedText[index];
            }
            return DecryptedPassword;
        }
    }
}

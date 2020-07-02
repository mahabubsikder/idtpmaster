using System;
using System.Text;

namespace IDTPBusinessLayerCore
{
    public class Cryptography : ICryptography
    {
        
      
        public  string DecryptPassword(string pass)//, out string returnValue)
        {
            string returnValue = string.Empty;
            //returnValue = String.Empty;
            try
            {
                returnValue = Decrypt(pass);
                return returnValue;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;

                throw e;
            }
        }

        
        public  string EncryptPassword(string passwordSalt ,string pass)//, out string returnValue)
        {            
            string returnValue = string.Empty;
            //returnValue = String.Empty;
            try
            {
                returnValue = Encrypt(passwordSalt.ToString(), pass.ToString());
                return returnValue;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;

                throw e;
            }
        }

        
        public  string GetPasswordSalt()
        {
          
            string returnValue = string.Empty;
            //returnValue = String.Empty;
            try
            {
                returnValue = GetRandomPasswordSalt();
                return returnValue;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;

                throw e;
            }
    
        }

        private static string GetRandomPasswordSalt()
        {
            try
            {
                int saltLength = 10;
                string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789~!@#$%^&*()_+|";
                string returnValue = string.Empty;

                Random random = new Random();
                StringBuilder sb = new StringBuilder(saltLength);
                for (int i = 0; i < saltLength; i++)
                {
                    int randomNumber = random.Next(0, characters.Length);
                    sb.Append(characters, randomNumber, 1);
                }
                returnValue = sb.ToString();
                return returnValue;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;

                throw e;
            }
        }

        private  string Encrypt(string passwordSalt, string clearPassword)
        {
            try
            {
                string returnValue = string.Empty;

                passwordSalt = GetHexString(passwordSalt);
                clearPassword = GetHexString(clearPassword);

                System.Security.Cryptography.HMACSHA1 hash = new System.Security.Cryptography.HMACSHA1();

                byte[] returnBytes = new byte[passwordSalt.Length / 2];
                for (int i = 0; i < returnBytes.Length; i++)
                    returnBytes[i] = Convert.ToByte(passwordSalt.Substring(i * 2, 2), 16);
                hash.Key = returnBytes;

                string encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(clearPassword)));

                string newPassword = string.Format("{0}{1}", passwordSalt, encodedPassword);
                byte[] bytes = Encoding.UTF8.GetBytes(newPassword);
                StringBuilder sb = new StringBuilder();
                foreach (byte bt in bytes)
                {
                    sb.AppendFormat("{0:x2}", bt);
                }
                returnValue = sb.ToString();
                return returnValue;

            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;

                throw e;
            }
        }

        private static string GetHexString(string input)
        {
            try
            {
                char[] values = input.ToCharArray();
                string hexOutput = string.Empty;
                foreach (char letter in values)
                    hexOutput = String.Concat(hexOutput, String.Format("{0:X}", Convert.ToInt32(letter)));
                return hexOutput;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;

                throw e;
            }
        }

        private  string Decrypt(string encryptedPassword)
        {
            try
            {
                string returnValue = string.Empty;

                int NumberChars = encryptedPassword.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(encryptedPassword.Substring(i, 2), 16);
                }

                return returnValue = System.Text.Encoding.UTF8.GetString(bytes);
            }
            catch(Exception e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;

                throw e;
            }
            //return returnValue.Substring(10);
        }

        public  bool DecryptAndCheck(string clearText, string salt, string encryptedPassword)
        {
            try
            {
                string encCode = EncryptPassword(salt, clearText);
                string midPhase1 = Decrypt(encryptedPassword);
                string midPhase2 = Decrypt(encCode);
                string hexsalt = GetHexString(salt);
                if (String.Compare(midPhase1.Replace(hexsalt, string.Empty), midPhase2.Replace(hexsalt, string.Empty)) == 0)
                    return true;
                return false;//.Substring(10);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;

                throw e;
            }
        }
    

    }
}

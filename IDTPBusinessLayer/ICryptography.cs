namespace IDTPBusinessLayerCore
{
    public interface ICryptography
    {
         string DecryptPassword(string pass);


         string EncryptPassword(string passwordSalt,string pass);


         string GetPasswordSalt();
            

         bool DecryptAndCheck(string clearText, string salt, string encryptedPassword);
    }
}

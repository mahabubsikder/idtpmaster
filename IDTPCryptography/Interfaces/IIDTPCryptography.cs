namespace Cryptography.Interfaces
{
    public interface IIDTPCryptography
    {
        string DecryptSecret(string pass);


        string EncryptSecret(string passwordSalt, string pass);


        string GetSecretSalt();


        bool DecryptAndCheck(string clearText, string salt, string encryptedPassword);
    }
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DopplerLib.Authentication
{
    public class HashingMachine
    {
        private string deviceId { get; set; }
        public HashingMachine(IDeviceIdentificator identificator)
        {
            this.deviceId = identificator.GetDeviceIdentificator();
        }
        public HashingMachine(string deviceId)
        {
            this.deviceId = deviceId;
        }
        public async Task<string> GenerateCredentialsHash(string UserName, string Password)
        {
            return Convert.ToBase64String(await GetComplexHash(UserName, Password));
        }
        private async Task<byte[]> GetComplexHash(string UserName, string Password)
        {
            byte[] userNameHash;
            byte[] passwordHash;
            byte[] deviceIdHash;
            using (SHA512 hasher = SHA512.Create())
            {
                userNameHash = hasher.ComputeHash(Encoding.UTF8.GetBytes(UserName));
                passwordHash = hasher.ComputeHash(Encoding.UTF8.GetBytes(Password));
                deviceIdHash = hasher.ComputeHash(Encoding.UTF8.GetBytes(deviceId));
            }
            byte[] resultHashesArray = new byte[userNameHash.Length + passwordHash.Length + deviceIdHash.Length];
            Array.Copy(userNameHash, 0, resultHashesArray, 0, userNameHash.Length);
            Array.Copy(passwordHash, 0, resultHashesArray, userNameHash.Length, passwordHash.Length);
            Array.Copy(deviceIdHash, 0, resultHashesArray, passwordHash.Length + passwordHash.Length, deviceIdHash.Length);
            byte[] returnhash = null;
            using (IncrementalHash hash = IncrementalHash.CreateHash(HashAlgorithmName.SHA512))
            {
                hash.AppendData(resultHashesArray);
                returnhash = hash.GetHashAndReset();
            }
            return returnhash;
        }
        public async Task<string> GenerateCompleteHash(string UserName, string Password)
        {
            byte[] destinationArray = null;
            using (SHA512 hasher = SHA512.Create())
            {
                byte[] dataHash = await GetComplexHash(UserName, Password);
                byte[] timeStampHash = hasher.ComputeHash(BitConverter.GetBytes(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 5000));
                destinationArray = new byte[dataHash.Length + timeStampHash.Length];
                Array.Copy(dataHash, 0, destinationArray, 0, dataHash.Length);
                Array.Copy(timeStampHash, 0, destinationArray, dataHash.Length, timeStampHash.Length);
            }
            byte[] hashBytes = new byte[36];
            using(RNGCryptoServiceProvider cryptoProvider = new RNGCryptoServiceProvider())
            {
                byte[] salt;
                cryptoProvider.GetBytes(salt = new byte[16]);
                Array.Copy(salt, 0, hashBytes, 0, salt.Length);
                using(Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(destinationArray, salt, 100000))
                {
                    byte[] hash = deriveBytes.GetBytes(20);
                    Array.Copy(hash, 0, hashBytes, salt.Length, hash.Length);
                }
            }
            return Convert.ToBase64String(hashBytes);
        }
        public async Task<string> GenerateCompleteHash()
        {
            return "";
        }
    }
}

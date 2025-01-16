using OtpNet;
using QRCoder;

namespace TwoFactorAuthentication.API.Services
{
    public class TwoFactorAuthService
    {
        public string GenerateSecretKey()
        {
            var secretKey = KeyGeneration.GenerateRandomKey(20);
            return Base32Encoding.ToString(secretKey);

        }

        public string GenerateQRCodeUri(string issuer, string username, string secretKey)
        {
            return $"otpaulth://totp/{issuer}:{username}?secret={secretKey}&issuer={issuer}";
        }

        public string GenerateQRCode(string uri)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(uri, QRCodeGenerator.ECCLevel.Q))
            using (var qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeImage = qrCode.GetGraphic(20);
                return Convert.ToBase64String(qrCodeImage);
            };
        }

        public bool ValidateCode(string secretKey, string code)
        {
            var totp = new Totp(Base32Encoding.ToBytes(secretKey));
            return totp.VerifyTotp(code, out _);
        }
    }
}

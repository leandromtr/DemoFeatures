using Microsoft.AspNetCore.Mvc;
using TwoFactorAuthentication.API.Services;

namespace TwoFactorAuthentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwoFactorAuthController : Controller
    {
        private readonly TwoFactorAuthService _twoFactorAuthService;

        public TwoFactorAuthController(TwoFactorAuthService twoFactorAuthService)
        {
            _twoFactorAuthService = twoFactorAuthService;
        }

        [HttpGet("Generate")]
        public IActionResult Index(string username)
        {
            var secretKey = _twoFactorAuthService.GenerateSecretKey();
            var issuer = "TwoFactorAuthenticationApp";
            var qrCodeUri = _twoFactorAuthService.GenerateQRCodeUri(issuer, username, secretKey);
            var qrCodeImage = _twoFactorAuthService.GenerateQRCode(qrCodeUri);

            return Ok(new
            {
                secretKey = secretKey,
                qrCodeImage = qrCodeImage
            });
        }

        [HttpPost("Validade")]
        public IActionResult Validade(string code, string secretKey)
        {
            var isValid = _twoFactorAuthService.ValidateCode(secretKey, code);
            if (isValid)
            {
                return Ok("Código válido.");
            }

            return Unauthorized("Código inválido.");
        }
    }
}

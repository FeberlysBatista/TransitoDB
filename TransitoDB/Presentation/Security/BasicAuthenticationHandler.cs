using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using TransitoDB.Infrastructure.Data;

namespace TransitoDB.Presentation.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public const string SchemeName = "Basic";
        private readonly TransitoDbContext _db;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            TransitoDbContext db)
            : base(options, logger, encoder, clock) => _db = db;

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(HeaderNames.Authorization))
                return AuthenticateResult.NoResult();

            var h = Request.Headers[HeaderNames.Authorization].ToString();
            if (!h.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                return AuthenticateResult.NoResult();

            string user, pass;
            try
            {
                var token = h.Substring("Basic ".Length).Trim();
                var raw = Encoding.UTF8.GetString(Convert.FromBase64String(token)).Split(':', 2);
                if (raw.Length != 2) return AuthenticateResult.Fail("Credenciales inválidas.");
                user = raw[0]; pass = raw[1];
            }
            catch { return AuthenticateResult.Fail("Formato Basic inválido."); }

            var emp = await _db.Empleados.Include(e => e.Cargo).FirstOrDefaultAsync(e => e.Documento == user);
            if (emp is null || !emp.Activo) return AuthenticateResult.Fail("Usuario no encontrado o inactivo.");

            // === SOLO PARA PROBAR ===
            if (pass != "123456") return AuthenticateResult.Fail("Contraseña inválida.");
            // =========================

            var role = emp.Cargo?.Nombre ?? "Usuario";

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, emp.EmpleadoId.ToString()),
                new Claim(ClaimTypes.Name, emp.Documento),
                new Claim(ClaimTypes.Role, role)
            };

            var id = new ClaimsIdentity(claims, SchemeName);
            var principal = new ClaimsPrincipal(id);
            var ticket = new AuthenticationTicket(principal, SchemeName);

            return AuthenticateResult.Success(ticket);
        }

        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = "Basic realm=\"TransitoAPI\"";
            return base.HandleChallengeAsync(properties);
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Text;

namespace Architect.API.Tron.Business.InsuredCompletion
{
    /// <summary>
    /// Genera y verifica secretos opacos de capacidad sin persistir sus valores en texto plano.
    /// </summary>
    public static class InvitationSecret
    {
        private const int SecretByteLength = 32;

        /// <summary>
        /// Genera 256 bits de datos aleatorios criptográficamente seguros codificados para uso seguro en un fragmento de URL.
        /// </summary>
        /// <returns>Un secreto de capacidad Base64URL sin relleno.</returns>
        public static string Generate()
        {
            byte[] bytes = new byte[SecretByteLength];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(bytes);
            }

            return Convert.ToBase64String(bytes)
                .TrimEnd('=')
                .Replace('+', '-')
                .Replace('/', '_');
        }

        /// <summary>
        /// Crea el verificador SHA-256 persistido para un secreto de capacidad.
        /// </summary>
        /// <param name="secret">Secreto en texto plano recibido únicamente en el límite del sistema.</param>
        /// <returns>Hash SHA-256 hexadecimal en minúscula.</returns>
        /// <exception cref="ArgumentException">Se produce cuando no se proporciona un secreto.</exception>
        public static string Hash(string secret)
        {
            if (string.IsNullOrEmpty(secret))
            {
                throw new ArgumentException("El secreto es obligatorio.", nameof(secret));
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(secret));
                StringBuilder builder = new StringBuilder(hash.Length * 2);
                foreach (byte value in hash)
                {
                    builder.Append(value.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Comprueba un secreto proporcionado contra su verificador almacenado mediante una comparación de longitud fija.
        /// </summary>
        /// <param name="secret">Secreto en texto plano presentado por el llamador.</param>
        /// <param name="expectedHash">Verificador SHA-256 persistido.</param>
        /// <returns><c>true</c> solo cuando el secreto proporcionado coincide con el verificador.</returns>
        public static bool Matches(string secret, string expectedHash)
        {
            if (string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(expectedHash))
            {
                return false;
            }

            byte[] actual = Encoding.UTF8.GetBytes(Hash(secret));
            byte[] expected = Encoding.UTF8.GetBytes(expectedHash);
            if (actual.Length != expected.Length)
            {
                return false;
            }

            int difference = 0;
            for (int index = 0; index < actual.Length; index++)
            {
                difference |= actual[index] ^ expected[index];
            }

            return difference == 0;
        }
    }
}

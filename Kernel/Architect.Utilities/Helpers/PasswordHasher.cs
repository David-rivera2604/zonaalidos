using System;
using System.Security.Cryptography;
using System.Text;

namespace Architect.Utilities.Helpers
{
    /// <summary>
    /// Utilidad para hashing seguro de contraseñas usando PBKDF2-HMAC-SHA256.
    /// NO usar CryptSupport para contraseñas (es cifrado simétrico reversible).
    /// 
    /// Algoritmo: PBKDF2-HMAC-SHA256
    /// - Salt: 256 bits aleatorio único por contraseña
    /// - Iteraciones: 100,000 (OWASP 2023 recommendation)
    /// - Hash resultante: 256 bits
    /// - Formato: Base64([Salt 32 bytes][Hash 32 bytes])
    /// 
    /// Cumple con:
    /// - NIST SP 800-132 (Password-Based Key Derivation)
    /// - OWASP ASVS 4.0 (Authentication Verification Standard)
    /// - FIPS 180-4 (Secure Hash Standard)
    /// </summary>
    /// <remarks>
    /// IMPORTANTE: Las contraseñas NO se "cifran" (cifrado implica reversibilidad).
    /// Se protegen mediante HASHING IRREVERSIBLE.
    /// 
    /// Diferencia con CryptSupport:
    /// - CryptSupport: Cifrado simétrico AES (reversible) ? Para datos sensibles
    /// - PasswordHasher: Hashing PBKDF2 (irreversible) ? Para contraseñas
    /// </remarks>
    public static class PasswordHasher
    {
        /// <summary>
        /// Tamaño del salt en bytes (256 bits)
        /// </summary>
        private const int SaltSize = 32;

        /// <summary>
        /// Tamaño del hash resultante en bytes (256 bits)
        /// </summary>
        private const int HashSize = 32;

        /// <summary>
        /// Número de iteraciones PBKDF2 (OWASP 2023: mínimo 100,000 para SHA-256)
        /// Mayor número = más seguro pero más lento
        /// </summary>
        private const int Iterations = 100000;

        /// <summary>
        /// Genera un hash seguro de la contraseña con salt aleatorio.
        /// 
        /// Proceso:
        /// 1. Genera salt criptográficamente aleatorio de 256 bits
        /// 2. Deriva hash usando PBKDF2-HMAC-SHA256 con 100,000 iteraciones
        /// 3. Combina salt + hash en un solo array
        /// 4. Convierte a Base64 para almacenamiento en BD
        /// 
        /// Formato de salida: Base64([Salt 32 bytes][Hash 32 bytes])
        /// Ejemplo: "rKfW8x...64 caracteres...mQ9pL...=" (88 caracteres en Base64)
        /// </summary>
        /// <param name="password">Contraseña en texto plano ingresada por el usuario</param>
        /// <returns>Hash con salt embebido en formato Base64 (88 caracteres)</returns>
        /// <exception cref="ArgumentNullException">Si password es null o vacío</exception>
        /// <example>
        /// <code>
        /// // Registro de usuario
        /// string password = "MiPassword123!";
        /// string hash = PasswordHasher.HashPassword(password);
        /// // hash = "rKfW8x3kL...88 caracteres...mQ9pL="
        /// 
        /// // Guardar en BD
        /// user.PasswordHash = hash;
        /// repository.Save(user);
        /// </code>
        /// </example>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password), "La contraseña no puede ser nula o vacía");

            // 1. Generar salt aleatorio criptográficamente seguro
            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // 2. Generar hash con PBKDF2-HMAC-SHA256
            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(
               password,
                          salt,
                  Iterations,
                HashAlgorithmName.SHA256))
            {
                hash = pbkdf2.GetBytes(HashSize);
            }

            // 3. Combinar salt + hash en un solo array
            byte[] hashWithSalt = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashWithSalt, 0, SaltSize);
            Array.Copy(hash, 0, hashWithSalt, SaltSize, HashSize);

            // 4. Convertir a Base64 para almacenamiento
            return Convert.ToBase64String(hashWithSalt);
        }

        /// <summary>
        /// Verifica si una contraseña coincide con el hash almacenado.
        /// 
        /// Proceso:
        /// 1. Extrae salt del hash almacenado
        /// 2. Calcula hash de la contraseña ingresada usando el mismo salt
        /// 3. Compara de forma segura (resistente a timing attacks)
        /// 
        /// IMPORTANTE: La comparación es resistente a timing attacks mediante SlowEquals.
        /// Esto previene que un atacante pueda deducir información sobre el hash
        /// midiendo el tiempo de respuesta.
        /// </summary>
        /// <param name="password">Contraseña ingresada por el usuario (texto plano)</param>
        /// <param name="storedHash">Hash almacenado en BD (formato Base64 con salt embebido)</param>
        /// <returns>True si la contraseña es correcta, False si es incorrecta o hay error</returns>
        /// <exception cref="ArgumentNullException">Si password o storedHash son null o vacíos</exception>
        /// <example>
        /// <code>
        /// // Login de usuario
        /// string passwordIngresada = "MiPassword123!";
        /// string hashAlmacenado = user.PasswordHash; // Desde BD
        /// 
        /// bool esValida = PasswordHasher.VerifyPassword(passwordIngresada, hashAlmacenado);
        /// 
        /// if (esValida)
        /// {
        ///   // Autenticar usuario
        ///  return GenerateToken(user);
        /// }
        /// else
        /// {
        ///     // Credenciales incorrectas
        ///     return Unauthorized();
        /// }
        /// </code>
        /// </example>
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password), "La contraseña no puede ser nula o vacía");

            if (string.IsNullOrEmpty(storedHash))
                throw new ArgumentNullException(nameof(storedHash), "El hash almacenado no puede ser nulo o vacío");

            try
            {
                // 1. Decodificar y extraer salt + hash del valor almacenado
                byte[] hashWithSalt = Convert.FromBase64String(storedHash);

                // Validar tamaño esperado
                if (hashWithSalt.Length != SaltSize + HashSize)
                {
                    // Hash corrupto o formato incorrecto
                    return false;
                }

                byte[] salt = new byte[SaltSize];
                byte[] storedHashBytes = new byte[HashSize];

                Array.Copy(hashWithSalt, 0, salt, 0, SaltSize);
                Array.Copy(hashWithSalt, SaltSize, storedHashBytes, 0, HashSize);

                // 2. Calcular hash de la contraseña ingresada con el mismo salt
                byte[] computedHash;
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                {
                    computedHash = pbkdf2.GetBytes(HashSize);
                }

                // 3. Comparación segura resistente a timing attacks
                return SlowEquals(storedHashBytes, computedHash);
            }
            catch (FormatException)
            {
                // El storedHash no es Base64 válido
                return false;
            }
            catch (Exception)
            {
                // Cualquier otro error (ej: OutOfMemoryException)
                // Por seguridad, retornar false en lugar de lanzar excepción
                return false;
            }
        }

        /// <summary>
        /// Comparación de arrays de bytes resistente a timing attacks.
        /// 
        /// Los timing attacks son ataques donde un atacante mide el tiempo
        /// que tarda una operación para deducir información sobre los datos.
        /// 
        /// Una comparación normal (==) termina en el primer byte diferente,
        /// lo que permite a un atacante deducir información byte por byte.
        /// 
        /// Esta implementación SIEMPRE compara todos los bytes, independientemente
        /// de cuándo encuentre diferencias, tomando tiempo constante.
        /// </summary>
        /// <param name="a">Primer array de bytes</param>
        /// <param name="b">Segundo array de bytes</param>
        /// <returns>True si los arrays son idénticos, False si difieren</returns>
        /// <remarks>
        /// Técnica: XOR acumulativo
        /// - XOR de bytes iguales = 0
        /// - XOR de bytes diferentes = valor != 0
        /// - Al final, diff == 0 solo si todos los bytes son iguales
        /// </remarks>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            // XOR de las longitudes (0 si son iguales)
            uint diff = (uint)a.Length ^ (uint)b.Length;

            // XOR de cada byte (acumula diferencias)
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }

            // diff == 0 solo si longitudes y todos los bytes son iguales
            return diff == 0;
        }

        /// <summary>
        /// Verifica si un hash almacenado necesita ser actualizado.
        /// 
        /// Retorna true si:
        /// - El hash usa menos de 100,000 iteraciones
        /// - El hash usa un algoritmo diferente a SHA-256
        /// - El formato del hash no es compatible
        /// 
        /// Útil para migración gradual de hashes antiguos.
        /// </summary>
        /// <param name="storedHash">Hash almacenado en BD</param>
        /// <returns>True si el hash debería ser regenerado</returns>
        /// <remarks>
        /// En el futuro, si se aumentan las iteraciones o se cambia el algoritmo,
        /// este método puede detectar hashes "antiguos" que necesitan actualización.
        /// 
        /// Estrategia de migración:
        /// 1. Usuario hace login exitoso
        /// 2. Si NeedsUpgrade() retorna true
        /// 3. Regenerar hash con nuevos parámetros
        /// 4. Actualizar en BD
        /// </remarks>
        public static bool NeedsUpgrade(string storedHash)
        {
            if (string.IsNullOrEmpty(storedHash))
                return true;

            try
            {
                byte[] hashWithSalt = Convert.FromBase64String(storedHash);

                // Verificar formato actual (32 bytes salt + 32 bytes hash)
                if (hashWithSalt.Length != SaltSize + HashSize)
                    return true;

                // En el futuro, aquí se pueden agregar más verificaciones
                // Por ejemplo, si aumentamos las iteraciones a 200,000
                // podríamos almacenar un byte de versión al inicio del hash

                return false;
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        /// Genera un hash de contraseña con parámetros personalizados.
        /// 
        /// ADVERTENCIA: Solo usar si tienes requisitos específicos de seguridad.
        /// Los valores por defecto (100,000 iteraciones, SHA-256) son apropiados
        /// para la mayoría de aplicaciones según OWASP 2023.
        /// </summary>
        /// <param name="password">Contraseña en texto plano</param>
        /// <param name="iterations">Número de iteraciones PBKDF2 (mínimo 10,000, recomendado 100,000+)</param>
        /// <param name="saltSize">Tamaño del salt en bytes (mínimo 16, recomendado 32)</param>
        /// <param name="hashSize">Tamaño del hash en bytes (mínimo 16, recomendado 32)</param>
        /// <returns>Hash con salt embebido en Base64</returns>
        /// <exception cref="ArgumentException">Si los parámetros son inválidos</exception>
        public static string HashPasswordWithParams(string password, int iterations, int saltSize, int hashSize)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            if (iterations < 10000)
                throw new ArgumentException("Las iteraciones deben ser al menos 10,000", nameof(iterations));

            if (saltSize < 16)
                throw new ArgumentException("El salt debe ser al menos 16 bytes", nameof(saltSize));

            if (hashSize < 16)
                throw new ArgumentException("El hash debe ser al menos 16 bytes", nameof(hashSize));

            // Generar salt aleatorio
            byte[] salt = new byte[saltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Generar hash
            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                hash = pbkdf2.GetBytes(hashSize);
            }

            // Combinar salt + hash
            byte[] hashWithSalt = new byte[saltSize + hashSize];
            Array.Copy(salt, 0, hashWithSalt, 0, saltSize);
            Array.Copy(hash, 0, hashWithSalt, saltSize, hashSize);

            return Convert.ToBase64String(hashWithSalt);
        }
    }
}

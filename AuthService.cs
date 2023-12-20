using System;
using System.Security.Cryptography;
using System.Text;

public class AuthService
{
    private readonly UserRepository userRepository;
    private string usernameHashAlgorithm = "MD5"; // Значение по умолчанию
    private string passwordHashAlgorithm = "MD5"; // Значение по умолчанию


    public AuthService(UserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public void SetUsernameHashAlgorithm(string algorithm)
    {
        usernameHashAlgorithm = algorithm;
    }

    public void SetPasswordHashAlgorithm(string algorithm)
    {
        passwordHashAlgorithm = algorithm;
    }

    public void RegisterUser(string username, string password, string role)
    {
        // Генерация случайной соли
        string salt = GenerateSalt();
        // Генерация случайной соли
        // Хешируем пароль перед сохранением в базу данных
        string passwordHash = HashPassword(password, salt);
        // Хешируем имя пользователя перед сохранением в базу данных
        string usernameHash = HashUsername(username);

        // Создаем нового пользователя
        try
        {
            var user = new User { Username = usernameHash, PasswordHash = passwordHash, Salt = salt, Role = role };
            // Сохраняем пользователя в базу данных
            userRepository.CreateUser(user);
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    private string GenerateSalt()
    {
        // Генерация случайной строки
        return Guid.NewGuid().ToString();
    }

    public bool AuthenticateUser(string username, string password, string requiredRole = null)
    {
        // Получаем пользователя из базы данных по имени пользователя
        var user = userRepository.GetUserByUsername(HashUsername(username));

        if (user != null && VerifyPassword(password, user.PasswordHash, user.Salt))
        {
            // Проверяем, совпадает ли роль пользователя с требуемой ролью (если требуется)
            if (requiredRole == null || string.Equals(user.Role, requiredRole, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private string HashPassword(string password, string salt)
    {
        using (var algorithm = GetHashAlgorithm(passwordHashAlgorithm))
        {
            // Конкатенация пароля и соли перед хешированием
            byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(password + salt);
            // Хешируем пароль с использованием выбранного алгоритма
            byte[] hashedBytes = algorithm.ComputeHash(saltedPasswordBytes);

            // Преобразуем байты в строку для хранения в базе данных
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    public string HashUsername(string username)
    {
        username = username.ToLower();
        using (var algorithm = GetHashAlgorithm(usernameHashAlgorithm))
        {
            byte[] saltedUsernameBytes = Encoding.UTF8.GetBytes(username);

            // Хеширование имени пользователя с использованием выбранного алгоритма
            byte[] hashedBytes = algorithm.ComputeHash(saltedUsernameBytes);

            // Преобразование байтов в строку для хранения в базе данных
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    private HashAlgorithm GetHashAlgorithm(string algorithmName)
    {
        switch (algorithmName)
        {
            case "MD5":
                return MD5.Create();
            case "SHA-1":
                return SHA1.Create();
            case "SHA-256":
                return SHA256.Create();
            case "SHA-384":
                return SHA384.Create();
            case "SHA-512":
                return SHA512.Create();
            default:
                throw new ArgumentException("Unsupported hash algorithm");
        }
    }

    private bool VerifyPassword(string password, string storedHash, string salt)
    {
        // Проверяем, совпадает ли хеш введенного пароля с хешем из базы данных
        return string.Equals(HashPassword(password, salt), storedHash, StringComparison.OrdinalIgnoreCase);
    }
}
using System;
using System.Security.Cryptography;
using System.Windows.Forms;
namespace Dtat_protection_forms
{
    public partial class Form1 : Form
    {
        private AuthService authService;
        private UserRepository userRepository;

        // Добавьте конструктор, принимающий authService и userRepository
        public Form1(AuthService authService, UserRepository userRepository)
        {
            InitializeComponent();
            this.authService = authService;
            this.userRepository = userRepository;

            // Заполнение ListBox-ов алгоритмами хэширования
            listBoxUsernameHashAlgorithms.Items.Add("MD5");
            listBoxUsernameHashAlgorithms.Items.Add("SHA-1");
            listBoxUsernameHashAlgorithms.Items.Add("SHA-256");
            listBoxUsernameHashAlgorithms.Items.Add("SHA-384");
            listBoxUsernameHashAlgorithms.Items.Add("SHA-512");

            listBoxPasswordHashAlghoritms.Items.Add("MD5");
            listBoxPasswordHashAlghoritms.Items.Add("SHA-1");
            listBoxPasswordHashAlghoritms.Items.Add("SHA-256");
            listBoxPasswordHashAlghoritms.Items.Add("SHA-384");
            listBoxPasswordHashAlghoritms.Items.Add("SHA-512");

            // Добавьте обработчики событий для ListBox-ов
            listBoxUsernameHashAlgorithms.SelectedIndexChanged += ListBoxUsernameHashAlgorithms_SelectedIndexChanged;
            listBoxPasswordHashAlghoritms.SelectedIndexChanged += ListBoxPasswordHashAlgorithms_SelectedIndexChanged;
        }
        private void ListBoxUsernameHashAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAlgorithm = listBoxUsernameHashAlgorithms.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedAlgorithm))
            {
                authService.SetUsernameHashAlgorithm(selectedAlgorithm);
            }
        }

        private void ListBoxPasswordHashAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAlgorithm = listBoxPasswordHashAlghoritms.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedAlgorithm))
            {
                authService.SetPasswordHashAlgorithm(selectedAlgorithm);
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string role = listBox1.SelectedItem?.ToString();

            // Проверка наличия данных
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Заполните все поля для регистрации.");
                return;
            }

            authService.RegisterUser(username, password, role);
            MessageBox.Show("Пользователь успешно зарегистрирован.");
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string role = listBox1.SelectedItem?.ToString();

            // Проверка наличия данных
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Заполните все поля для входа.");
                return;
            }

            bool isAuthenticated = authService.AuthenticateUser(username, password, role);

            if (isAuthenticated)
            {
                MessageBox.Show("Пользователь успешно аутентифицирован.");

                // Получаем пользователя из базы данных по имени
                var user = userRepository.GetUserByUsername(authService.HashUsername(username));

                if (user != null)
                {
                    // Очищаем dataGridViewUsers
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add("Id", "Id");
                    dataGridView1.Columns.Add("Username", "Username");
                    dataGridView1.Columns.Add("PasswordHash", "PasswordHash");
                    dataGridView1.Columns.Add("Salt", "Salt");
                    dataGridView1.Columns.Add("Role", "Role");
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    // Добавляем пользователя в dataGridViewUsers
                    dataGridView1.Rows.Add(user.Id, user.Username, user.PasswordHash, user.Salt, user.Role);
                }
                else
                {
                    MessageBox.Show("Пользователь не найден в базе данных.");
                }
            }
            else
            {
                MessageBox.Show("Ошибка аутентификации. Пользователь не найден или введен неверный пароль.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Windows.Forms;

namespace UserRegistration
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "User Registration";
            this.Width = 400;
            this.Height = 300;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblUsername = new Label { Text = "Username:", Left = 20, Top = 20, Width = 100 };
            TextBox txtUsername = new TextBox { Left = 130, Top = 20, Width = 200 };

            Label lblEmail = new Label { Text = "Email:", Left = 20, Top = 60, Width = 100 };
            TextBox txtEmail = new TextBox { Left = 130, Top = 60, Width = 200 };

            Label lblPassword = new Label { Text = "Password:", Left = 20, Top = 100, Width = 100 };
            TextBox txtPassword = new TextBox { Left = 130, Top = 100, Width = 200, PasswordChar = '*' };

            Label lblConfirmPassword = new Label { Text = "Confirm Password:", Left = 20, Top = 140, Width = 100 };
            TextBox txtConfirmPassword = new TextBox { Left = 130, Top = 140, Width = 200, PasswordChar = '*' };

            Button btnRegister = new Button { Text = "Register", Left = 130, Top = 190, Width = 80 };
            btnRegister.Click += (s, e) => RegisterUser(txtUsername.Text, txtEmail.Text, txtPassword.Text, txtConfirmPassword.Text);

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblConfirmPassword);
            this.Controls.Add(txtConfirmPassword);
            this.Controls.Add(btnRegister);
        }

        private void RegisterUser(string username, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Registration successful!\nUsername: {username}\nEmail: {email}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new RegistrationForm());
        }
    }
}
using CommServices.Core.Abstract.Entity;
using CommServices.Core.Abstract.Repository;
using System;
using System.Windows.Forms;

namespace PaymentForCommServices
{
    public partial class AuthorizationForm : Form
    {
        readonly IUserRepository userRepository;
        public AuthorizationForm(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
            InitializeComponent();

        }

        private void EntranceButton_Click(object sender, EventArgs e)
        {
            var user = new User() { UserName = UserNameInput.Text, Password = PasswordInput.Text };
            if (userRepository.AuthorizationUser(user))
            {
                MessageBox.Show("Добро пожаловать!");
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {

        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            var createUserForm = new CreateUserForm();
            createUserForm.ShowDialog();
            var user = new User()
            {
                Name = createUserForm.NameRegInput.Text,
                LastName = createUserForm.LastNameRegInput.Text,
                Email = createUserForm.EmailRegInput.Text,
                UserName = createUserForm.UserNameRegInput.Text,
                Password = createUserForm.PasswordRegInput.Text,
            };

            MessageBox.Show($"Будет записан такой пользователь: {user.Name}");
        }
    }
}

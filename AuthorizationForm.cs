using CommServices.Core.Abstract.EntityCore;
using CommServices.Core.Abstract.Repository;
using CommServices.Core.Abstract.Validations;
using CommServices.Core.Entity;
using System;
using System.Windows.Forms;

namespace PaymentForCommServices
{
    public partial class AuthorizationForm : Form
    {
        readonly IUserRepository userRepository;
        readonly IUserInputValidation userInputValidation;
        readonly ICreateUserRepository createUserRepository;
        public AuthorizationForm(
            IUserRepository _userRepository, 
            IUserInputValidation _userInputValidation,
            ICreateUserRepository _createUserRepository)
        {
            userRepository = _userRepository;
            userInputValidation = _userInputValidation;
            createUserRepository = _createUserRepository;
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
            var createUserForm = new CreateUserForm(userRepository, userInputValidation, createUserRepository);
            createUserForm.ShowDialog();
        }
    }
}

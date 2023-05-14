using CommServices.Core.Abstract.EntityCore;
using CommServices.Core.Abstract.Repository;
using CommServices.Core.Abstract.Validations;
using CommServices.Core.Entity;
using System;
using System.Windows.Forms;

namespace PaymentForCommServices
{
    public partial class CreateUserForm : Form
    {
        readonly IUserRepository userRepository;
        readonly IUserInputValidation userInputValidaton;
        readonly ICreateUserRepository createUserRepository;
        public CreateUserForm(
            IUserRepository _userRepository, 
            IUserInputValidation _userInputValidation,
            ICreateUserRepository _createUserRepository)
        {
            userRepository = _userRepository;
            userInputValidaton = _userInputValidation;
            createUserRepository = _createUserRepository;
            InitializeComponent();
        }

        private void CreateUserForm_Load(object sender, EventArgs e)
        {
        }

        private void AddUseerRegButton_Click(object sender, EventArgs e)
        {
            var user = new User()
            {
                Name = NameRegInput.Text,
                LastName = LastNameRegInput.Text,
                Email = EmailRegInput.Text,
                UserName = UserNameRegInput.Text,
                Password = PasswordRegInput.Text,
            };

            if(!createUserRepository.RegisteringNewUser(user))
            {
                UserNameRegInput.Clear();
                PasswordRegInput.Clear();
                UserNameRegValidLabel.Visible = true;
                PasswordRegValidlabel.Visible = true;
                RepetPasswordRegLabel.Visible = true;
            }
            else
            {
                UserNameRegValidLabel.Visible = false;
                PasswordRegValidlabel.Visible = false;
                RepetPasswordRegLabel.Visible = false;
                Close();
            }
        }
    }
}

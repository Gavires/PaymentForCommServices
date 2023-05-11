using CommServices.Core.Abstract.Entity;
using CommServices.Core.Abstract.Repository;
using CommServices.Core.DataBase;
using System;
using System.Windows.Forms;

namespace PaymentForCommServices
{
    public partial class Form1 : Form
    {
        readonly IUserRepository userRepository;
        public Form1(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {           
            var user = new User
            {
                UserName = "Spartak",
                Name = "Спартак",
                LastName = "Сариев",
                Password = "Dff",
                IsAdmin = false
            };
            var admin = new Admin
            {
                LoginName = "Adm"
            };            
            //if (admin.IsAdmin) {
            //    try {
            //        userRepository.AddUser(user);
            //        var users = userRepository.Get(1);
            //        MessageBox.Show(users.Name);
            //        Close();
            //    }
            //    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            //}

            if(userRepository.AutorizationUser(user))
            {
                MessageBox.Show($"Доступ открыт {user.Name}");
            }
            else
            {
                MessageBox.Show("Неверное имя или пароль!");
            }

            MessageBox.Show("Добрый день!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

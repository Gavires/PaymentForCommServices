using CommServices.Core.Abstract.Repository;
using CommServices.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaymentForCommServices {
    public class Run {
        public IUserRepository userRepository;
        public Run () {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthorizationForm(userRepository)); }
    }
}

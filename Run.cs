using CommServices.Core.Abstract.Repository;
using CommServices.Core.Abstract.Validations;
using CommServices.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaymentForCommServices {
    public class Run {
    private readonly IUserRepository userRepository;
    private readonly IUserInputValidation userInputValidation;
    private readonly ICreateUserRepository createUserRepository;

    public Run(IUserRepository userRepository, IUserInputValidation userInputValidation, ICreateUserRepository createUserRepository) {
        this.userRepository = userRepository;
        this.userInputValidation = userInputValidation;
        this.createUserRepository = createUserRepository;
    }

    public void Start() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        try {
            var form = new AuthorizationForm(userRepository, userInputValidation, createUserRepository);
            RunFormAsync(form);
        }
        catch (Exception ex) {
            // handle exceptions
        }
    }

    private async void RunFormAsync(Form form) {
        await Task.Run(() => {
            Application.Run(form);
        });
    }
}
}

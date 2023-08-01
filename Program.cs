using CommServices.Core.DataBase;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System;
using System.Windows.Forms;
using CommServices.Core.Abstract.EntityCore;
using CommServices.Core.Abstract.Repository;
using CommServices.Core.Repository;
using CommServices.Core.Abstract.Validations;
using CommServices.Core.Validations;

namespace PaymentForCommServices {
    internal class Program {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<AuthorizationForm>());
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder() {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<AuthorizationForm>()
                    .AddScoped<BaseDb>(_ => new PCS())
                    .AddScoped<IUserRepository>(_ => new UserRepository(new PCS()))
                    .AddScoped<IUserInputValidation>(_ => new UserInputValidation())
                    .AddScoped<IUserRegistrationHistoryRepository>(_ => new UserRegistrationHistoryRepository(new PCS(), new UserRepository(new PCS())));
                    services.AddScoped<ICreateUserRepository>(serviceProvider =>
                    {
                        var validation = serviceProvider.GetRequiredService<IUserInputValidation>();
                        var userRepository = serviceProvider.GetRequiredService<IUserRepository>();
                        var userRegistrationHistoryRepository = serviceProvider.GetRequiredService<IUserRegistrationHistoryRepository>();
                        return new CreateUserRepository(validation, userRepository, userRegistrationHistoryRepository);
                    });
                    //.AddScoped<ICreateUserRepository>(_ => new CreateUserRepository(new UserInputValidation(), new UserRepository(new PCS())));
                    //.AddTransient<CreateUserForm>()
                    //.AddScoped<BaseDb>(_ => new PCS())
                    //.AddScoped<IUserRepository>(_ => new UserRepository(new PCS()));
                    
                    //services.AddTransient<Form1>();
                });
        }
    }
}

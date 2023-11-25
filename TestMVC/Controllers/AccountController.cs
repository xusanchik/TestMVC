using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using NToastNotify;
using Polly;
using System;
using TestMVC.Dto_s;
using TestMVC.FluentValidation;
using TestMVC.Interface;
using TestMVC.Models;
using TestMVC.Models.ERole;
using Windows.ApplicationModel.Contacts;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace TestMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IToastNotification _toastNotification;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(IToastNotification toastNotification, IUserRepository userRepository, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _toastNotification = toastNotification;
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        public IActionResult RegisterAdmin() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAdmin(AdminDto model)
        {
            var validationResult = await new RegisterAdminEmail().ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(model);
            }
            try
            {
                await _userRepository.RegisterAdmin(model);

                _toastNotification.AddSuccessToastMessage("Registration successfully!");

                return RedirectToAction("Login", "Account");

            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
                return View(model);
            }
        }

        public IActionResult Register() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterDto model)
        {
            var validationResult = await new RegisterModelValidator().ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);
            }
            try
            {
                if (ModelState.IsValid) await _userRepository.Register(model);
                _toastNotification.AddSuccessToastMessage("Registration successfully!");
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
                return View(model);
            }
        }
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var validationResult = await new LoginModelValidator().ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(model);
            }

            var retryPolicy = Policy.Handle<Exception>()
                .RetryAsync(3, (exception, retryCount) =>
                {
                    Console.WriteLine($"An exception occurred during login. Retry attempt: {retryCount}. Exception: {exception}");
                });

            try
            {
                var signInResult = await retryPolicy.ExecuteAsync(async () =>
                {
                    var result = await _userRepository.Login(model);
                    return result;
                });


                return RedirectToAction("Index", "Task");
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
                return View(model);
            }
        }
        public IActionResult AccessDenied() => RedirectToAction("Index", "Products");

        public IActionResult EmailSender() => View();
        [HttpPost]
        public async Task<IActionResult> EmailSender(EmailSenderDto emailSenderDto)
        {
            if (ModelState.IsValid)
            {
                return View("Error");
            }
            Random random = new Random();
            int otp = random.Next(10000000, 99999999);
            var email = new MimeMessage();
            var existUser = await _userManager.FindByEmailAsync(emailSenderDto.Email);
            
            email.From.Add(MailboxAddress.Parse("samadovxusan9013@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailSenderDto.Email));
            email.Subject = "Your verification code";
            email.Body = new TextPart(TextFormat.Html) { Text = "Your verification code is " + existUser.PhoneNumber};

            var smpt = new SmtpClient();
            await smpt.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smpt.AuthenticateAsync("samadovxusan9013@gmail.com", "dixaxlwqasgetqlb");
            await smpt.SendAsync(email);
            await smpt.DisconnectAsync(true);

            _toastNotification.AddSuccessToastMessage("Seng Massage Success");
            return RedirectToAction("Login", "Account");

        }
        public async Task<IActionResult> Main()
        {
            return View();
        }


    }
}

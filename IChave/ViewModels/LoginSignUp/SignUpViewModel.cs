using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IChave.DTO;
using IChave.ModelRealm;
using IChave.Models;
using IChave.Services;
using IChave.Validators;
using IChave.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Realms;
using Refit;

namespace IChave.ViewModels.LoginSignUp
{
    public class SignUpViewModel: ViewModelBase
    {
        protected SignUpViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
        }

        #region Fields
        private List<string> _sexList = Utils.SexList;
        public List<string> SexList
        {
            get => _sexList;
            set => SetProperty(ref _sexList, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _cpf;
        public string Cpf
        {
            get => _cpf;
            set => SetProperty(ref _cpf, value);
        }

        private string _sex = Utils.SexList.First();
        public string Sex
        {
            get => _sex;
            set => SetProperty(ref _sex, value);
        }

        private DateTime _birthdate = new DateTime(2000, 01, 01);
        public DateTime Birthdate
        {
            get => _birthdate;
            set => SetProperty(ref _birthdate, value);
        }

        private string _cellphone;
        public string Cellphone
        {
            get => _cellphone;
            set => SetProperty(ref _cellphone, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _confirmEmail;
        public string ConfirmEmail
        {
            get => _confirmEmail;
            set => SetProperty(ref _confirmEmail, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }
        #endregion

        private DelegateCommand registerCommand;
        public DelegateCommand RegisterCommand => registerCommand ??= new DelegateCommand(async () => await RegisterAsync(), () => !IsBusy);

        private async Task RegisterAsync()
        {
            try
            {
                IsBusy = true;
                UserVal _user = new UserVal()
                {
                    name = this.Name,
                    cpf = this.Cpf,
                    cell_phone = this.Cellphone,
                    sex = this.Sex,
                    birthdate = this.Birthdate,
                    email = this.Email,
                    confirm_email = this.ConfirmEmail,
                    password = this.Password,
                    confirm_password = this.ConfirmPassword
                };
                var resultValidation = new UserValidator().Validate(_user);
                if (resultValidation.IsValid)
                {
                    var usuarioAPI = RestService.For<IRestApi>(EndPoints.BaseUrl);
                    User _userDto = new User(_user);
                    try
                    {
                        var usuariosRetorno = await usuarioAPI.Create(_userDto);
                        if (usuariosRetorno.msg == MsgDTO.SUCESS)
                        {
                            var loginRetorno = await usuarioAPI.Login(_userDto);
                            if (loginRetorno.msg == MsgDTO.SUCESS)
                            {
                                var realm = Realm.GetInstance();
                                realm.Write(() =>
                                {
                                    realm.RemoveAll<TokenRealm>();
                                    realm.Add(new TokenRealm(loginRetorno));
                                });
                                await PageDialogService.DisplayAlertAsync(string.Empty, "Registration completed", "OK");
                                await NavigationService.NavigateAsync($"/NavigationPage/MenuView");
                            }
                        }
                    }
                    catch (ApiException ex)
                    {
                        await PageDialogService.DisplayAlertAsync(ex.StatusCode.ToString(), ex.GetContentAsAsync<MsgDTO>().Result.msg, "OK");
                    }
                }
                else
                {
                    await PageDialogService.DisplayAlertAsync("Required fields", string.Join("\n", resultValidation.Errors), "OK");
                }
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

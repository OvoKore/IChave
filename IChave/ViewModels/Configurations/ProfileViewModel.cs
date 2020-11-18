using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IChave.DTO;
using IChave.ModelRealm;
using IChave.Models;
using IChave.Validators;
using IChave.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Realms;

namespace IChave.ViewModels.Configurations
{
    public class ProfileViewModel : ViewModelBase
    {
        protected ProfileViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
        }

        #region Fields
        private List<string> _sexList = Utils.SexList;
        public List<string> SexList
        {
            get => _sexList;
            set => SetProperty(ref _sexList, value);
        }

        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _cell_phone;
        public string CellPhone
        {
            get => _cell_phone;
            set => SetProperty(ref _cell_phone, value);
        }

        private string _cpf;
        public string Cpf
        {
            get => _cpf;
            set => SetProperty(ref _cpf, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _sex;
        public string Sex
        {
            get => _sex;
            set => SetProperty(ref _sex, value);
        }

        private DateTime _birthdate;
        public DateTime Birthdate
        {
            get => _birthdate;
            set => SetProperty(ref _birthdate, value);
        }
        #endregion

        public override void Initialize(INavigationParameters parameters)
        {
            GetUser();
        }

        public async void GetUser()
        {
            try
            {
                IsBusy = true;
                var apiRetorno = await Utils.GetApi().GetUser();
                Name = apiRetorno.name;
                Email = apiRetorno.email;
                CellPhone = apiRetorno.cell_phone;
                Cpf = apiRetorno.cpf;
                Sex = SexList.Where(x => x == apiRetorno.sex).First();
                Birthdate = apiRetorno.birthdate;
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

        private DelegateCommand changePasswordCommand;
        public DelegateCommand ChangePasswordCommand => changePasswordCommand ??= new DelegateCommand(async () => await Navigation("ChangePasswordView"), () => !IsBusy);

        private DelegateCommand updateCommand;
        public DelegateCommand UpdateCommand => updateCommand ??= new DelegateCommand(async () => await UpdateAsync(), () => !IsBusy);

        private async Task UpdateAsync()
        {
            try
            {
                IsBusy = true;
                SmallUserVal _user = new SmallUserVal()
                {
                    name = Name,
                    cpf = Cpf,
                    cell_phone = CellPhone,
                    email = Email,
                    sex = Sex,
                    birthdate = Birthdate
                };
                var resultValidation = new SmallUserValidator().Validate(_user);
                if (resultValidation.IsValid)
                {
                    User _userDto = new User()
                    {
                        name = Name,
                        cell_phone = CellPhone.Replace("(", "").Replace(")", "").Replace("-", ""),
                        email = Email.ToLower(),
                        cpf = Cpf.Replace(".", "").Replace("-", ""),
                        sex = Sex,
                        birthdate = Birthdate
                    };
                    MsgDTO apiRetorno = await Utils.GetApi().UpdateUser(_userDto);
                    if (apiRetorno.msg == MsgDTO.SUCESS)
                    {
                        await PageDialogService.DisplayAlertAsync("Update", "User updated!", "OK");
                        await NavigationService.GoBackAsync();
                    }
                    else
                    {
                        await PageDialogService.DisplayAlertAsync("Erro", apiRetorno.msg, "OK");
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
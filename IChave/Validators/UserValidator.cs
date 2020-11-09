using System;
using FluentValidation;

namespace IChave.Validators
{
    public class UserPassword
    {
        public string current_password { get; set; }
        public string new_password { get; set; }
        public string confirm_password { get; set; }
    }

    public class UserPasswordValidator : AbstractValidator<UserPassword>
    {
        public UserPasswordValidator()
        {
            RuleFor(x => x.current_password).Must(Utils.PasswordValidator).NotNull();
            RuleFor(x => x.new_password).Must(Utils.PasswordValidator).NotNull();
            RuleFor(x => x.confirm_password).Equal(x => x.new_password).NotNull();
        }
    }

    public class SmallUserVal
    {
        public string email { get; set; }
        public string name { get; set; }
        public string cell_phone { get; set; }
        public string cpf { get; set; }
        public string sex { get; set; }
        public DateTime birthdate { get; set; }
    }

    public class SmallUserValidator : AbstractValidator<SmallUserVal>
    {
        public SmallUserValidator()
        {
            RuleFor(x => x.name).Length(2, 50).NotNull();
            RuleFor(x => x.cell_phone).Length(14).NotNull();
            RuleFor(x => x.cpf).Must(Utils.CpfValidator).NotNull();
            RuleFor(x => x.email).EmailAddress().NotNull();
            RuleFor(x => x.sex).NotNull();
            RuleFor(x => x.birthdate).NotNull();
        }
    }

    public class UserVal : SmallUserVal
    {
        public string confirm_email { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }
    }

    public class UserValidator : AbstractValidator<UserVal>
    {
        public UserValidator()
        {
            RuleFor(x => x.name).Length(2, 50).NotNull();
            RuleFor(x => x.cell_phone).Length(14).NotNull();
            RuleFor(x => x.cpf).Must(Utils.CpfValidator).NotNull();
            RuleFor(x => x.password).Must(Utils.PasswordValidator).NotNull();
            RuleFor(x => x.confirm_password).Equal(x => x.password).NotNull();
            RuleFor(x => x.email).EmailAddress().NotNull();
            RuleFor(x => x.confirm_email).Equal(x => x.email).NotNull();
            RuleFor(x => x.sex).NotNull();
            RuleFor(x => x.birthdate).NotNull();
        }
    }
}

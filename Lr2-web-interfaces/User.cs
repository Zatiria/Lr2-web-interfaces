using FluentValidation;

namespace Lr2_web_interfaces
{
    internal class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Ім'я не повинно бути порожнім"); 
            RuleFor(user => user.Name).Length(2, 50).WithMessage("Ім'я повинно бути від 2 до 50 символів");
            RuleFor(user => user.Age).InclusiveBetween(18, 60).WithMessage("Вік повинен бути між 18 і 60");
        }
    }
}

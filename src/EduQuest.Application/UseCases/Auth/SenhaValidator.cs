using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EduQuest.Application.UseCases.Usuarios
{
    public partial class PasswordValidator<T> : PropertyValidator<T, string>
    {
        public string ERROR_MESSAGE_KEY = "ErrorMessage";
        public override string Name => "PasswordValidator";
        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Sua senha deve ter no mínimo 8 caracteres, contendo pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial (por exemplo, !, ?, *, ., @).");
                return false;
            }

            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Sua senha deve ter no mínimo 8 caracteres, contendo pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial (por exemplo, !, ?, *, ., @).");
                return false;
            }

            if (!LowerCaseLetter().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Sua senha deve ter no mínimo 8 caracteres, contendo pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial (por exemplo, !, ?, *, ., @).");
                return false;
            }

            if (!UpperCaseLetter().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Sua senha deve ter no mínimo 8 caracteres, contendo pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial (por exemplo, !, ?, *, ., @).");
                return false;
            }

            if (!Numbers().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Sua senha deve ter no mínimo 8 caracteres, contendo pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial (por exemplo, !, ?, *, ., @).");
                return false;
            }

            if (!SpecialSymbols().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Sua senha deve ter no mínimo 8 caracteres, contendo pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial (por exemplo, !, ?, *, ., @).");
                return false;
            }

            return true;
        }

        [GeneratedRegex(@"[a-z]+")]
        private static partial Regex LowerCaseLetter();
        [GeneratedRegex(@"[A-Z]+")]
        private static partial Regex UpperCaseLetter();
        [GeneratedRegex(@"[0-9]+")]
        private static partial Regex Numbers();
        [GeneratedRegex(@"[\!\?\*\.\@]+")]
        private static partial Regex SpecialSymbols();
    }
}

using Socialite.Application.Exceptions.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services
{
    public class BaseValidator<T> where T : Xeptions.Xeption, new()
    {
        protected static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var authenticationValidationException = new T();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (!rule.Condition)
                {
                    authenticationValidationException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            authenticationValidationException.ThrowIfContainsErrors();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Utils
{
    public class NameValidationReason
    {
        public static readonly string CantBeEmpty = "CantBeEmpty";
        public static readonly string NameStartsWithDigit = "NameStartsWithDigit";
        public static readonly string NameIncludesInvalidCharacters = "NameIncludesInvalidCharacters";
    }

    public class ECNameValidation
    {
        public static bool IsValid(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            return name.Length != 0 && !char.IsDigit(name[0]) && ECNameValidation.IsValidAlphaNumericString(name);
        }

        public static bool IsValid(string name, out string validationMessage)
        {
            if (string.IsNullOrEmpty(name))
            {
                validationMessage = NameValidationReason.CantBeEmpty;
                return false;
            }
            if (char.IsDigit(name[0]))
            {
                validationMessage = string.Format(CultureInfo.CurrentCulture, NameValidationReason.NameStartsWithDigit, name);
                return false;
            }
            if (!ECNameValidation.IsValidAlphaNumericString(name))
            {
                validationMessage = string.Format(CultureInfo.CurrentCulture, NameValidationReason.NameIncludesInvalidCharacters, name);
                return false;
            }
            validationMessage = string.Empty;
            return true;
        }

        public static void Validate(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            if (name.Length == 0)
            {
                throw new InvalidECNameException(NameValidationReason.CantBeEmpty);
            }
            if (char.IsDigit(name[0]))
            {
                throw new InvalidECNameException(NameValidationReason.NameStartsWithDigit, name);
            }
            if (!ECNameValidation.IsValidAlphaNumericString(name))
            {
                throw new InvalidECNameException(NameValidationReason.NameIncludesInvalidCharacters, name);
            }
        }

        public static bool IsValidAlphaNumericString(string name)
        {
            foreach (char c in name)
            {
                if (!IsValidAlphaNumericChar(c)) return false;
            }
            return true;
        }

        public static bool IsValidAlphaNumericChar(char invalidChar)
        {
            return (invalidChar >= '0' && invalidChar <= '9') || (invalidChar >= 'A' && invalidChar <= 'Z') || (invalidChar >= 'a' && invalidChar <= 'z') || invalidChar == '_';
        }
    }


    [Serializable]
    public class InvalidECNameException : Exception
    {
        public InvalidECNameException() { }
        public InvalidECNameException(string message) : base(message) { }
        public InvalidECNameException(string message, string name) : base(string.Concat(message, ".", $"name:{name}")) { }
        public InvalidECNameException(string message, Exception inner) : base(message, inner) { }
        protected InvalidECNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }


    }
}

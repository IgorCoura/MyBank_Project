using System;
using System.Collections.Generic;

namespace Aurora.Domain.ValueTypes
{
    public struct CPF
    {
        private readonly string _value;

        private CPF(string value)
        {
            _value = value.Trim();
            _value = _value.Replace(".", "").Replace("-", "");
            Validate();
        }

        public override string ToString() =>
            _value;

        public static implicit operator CPF(string input) =>
            new CPF(input);

        public static bool operator ==(CPF c1, CPF c2) => c1.ToString() == c2.ToString();
        public static bool operator !=(CPF c1, CPF c2) => c1.ToString() != c2.ToString();


        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(_value))
            {
                throw new Exception("Is necessary to inform the CPF.");
            }

            int[] multiplierOne = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierTwo = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            List<string> cpfInvalido = new List<string> { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };
            string aux;
            string digit;
            int sum, rest;

            var value = _value;

            if (value.Length != 11)
            {
                throw new Exception("CPF should have 11 chars.");
            }

            foreach (string item in cpfInvalido)
            {
                if (item == _value)
                {
                    throw new Exception("This CPF is invalid.");
                }
            }

            aux = value.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(aux[i].ToString()) * multiplierOne[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            aux = aux + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(aux[i].ToString()) * multiplierTwo[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            if (!value.EndsWith(digit))
            {
                throw new Exception("This CPF is invalid.");
            }
        }
    }
}
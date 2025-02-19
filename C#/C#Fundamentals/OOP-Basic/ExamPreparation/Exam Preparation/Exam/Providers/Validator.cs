﻿using System;
using System.Text.RegularExpressions;
  static class Validator
    {

        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }
        public static void ValidateLessThenValue(int value, int min, string message)
        {
            if (value < min)
            {
                throw new ArgumentException(message);
            }
        }
        public static void ValidateMoreThenValue(int value, int max, string message)
        {
            if (value > max)
            {
                throw new ArgumentException(message);
            }
        }
        public static void ValidateDecimalRange(decimal value, decimal min, decimal max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateNull(object value, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ValidateSymbols(string value, string pattern, string message)
        {
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            if (!regex.IsMatch(value))
            {
                throw new ArgumentException(message);
            }
        }
    }

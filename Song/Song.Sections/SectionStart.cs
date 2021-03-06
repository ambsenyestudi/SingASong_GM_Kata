﻿using SingASong.SharedKernel;
using System.Collections.Generic;

namespace Song.Sections
{
    internal class SectionStart : ValueObject
    {
        private const string TEXT = "There was an old lady who swallowed a ";
        internal string Value { get; }
        internal SectionStart(string animal, string separtor = ";")
        {
            Value = TEXT + animal + separtor;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
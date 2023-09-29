using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Exceptions {
    internal class CharacterException : Exception {
        public CharacterException(string? message) : base(message) {

        }
    }
}
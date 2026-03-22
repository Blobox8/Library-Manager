using System;

namespace Library
{
    class LoginService
    {
        private static int PIN = 1234;

        public static bool  Authenticate(int pin)
        {
            return pin == PIN;
        }

    }
}

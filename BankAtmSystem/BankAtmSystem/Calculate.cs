using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAtmSystem
{
    class Calculate
    {
        public static float Minus_Balance(User p, float num)
        {
            return p.balance - num;
        }
        public static float Minus_WithdrawLimit(User p, float num)
        {
            return p.withdraw_limit - num;
        }
        public static float Plus_Balance(User p, float num)
        {
            return p.balance + num;
        }
        public static float Plus_WithdrawLimit(User p, float num)
        {
            return p.withdraw_limit + num;
        }
    }
}

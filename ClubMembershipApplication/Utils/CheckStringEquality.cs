using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Utils
{
    public static class CheckStringEquality
    {
        public static bool CheckEquality(string v1, string v2) => v1.Trim().ToLower() == v2.Trim().ToLower();
    }
}

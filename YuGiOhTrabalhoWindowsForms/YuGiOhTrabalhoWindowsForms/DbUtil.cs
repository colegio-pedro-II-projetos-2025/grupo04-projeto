using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOhTrabalhoWindowsForms
{
    internal static class DbUtil
    {
        public static string ConnectionString { get; } =
            "server=localhost;database=tcccarta;uid=root;pwd=;"; //uid=root / uid=3310

        /*public static string ConnectionString { get; } =
            "server=localhost;database=tcccarta;uid=root;pwd=;"; //uid=root / uid=3310
        */
    }
}

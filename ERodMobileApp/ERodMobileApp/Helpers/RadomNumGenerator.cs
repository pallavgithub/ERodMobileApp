using System;
namespace ERodMobileApp.Helpers
{
    public static class RadomNumGenerator
    {
        public static string RadomNumber()
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            int s = r.Next(10000, 99999);     
            return s.ToString("D4");

        }
    }
}

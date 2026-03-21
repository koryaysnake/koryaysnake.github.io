using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace WindowsFormsApp1
{
    internal static class Program
    {  //hello
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()

        {
            var url =  "https://rvwwsgpmzhnlklhahiqx.supabase.courl";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InJ2d3dzZ3BtemhubGtsaGFoaXF4Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NzMzNzc4NTksImV4cCI6MjA4ODk1Mzg1OX0.Dru6k5l4FepuoPTk37rDTYm_4dAVU5_Y5xCB64oxoH8";
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };
            var supabase = new Supabase.Client(url, key, options);
            supabase.InitializeAsync();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
        }
    }
}

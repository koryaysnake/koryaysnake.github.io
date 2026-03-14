using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace WindowsFormsApp1
{
    [Table("praktDaria")] 
    public class UserModel : BaseModel
    {
        [PrimaryKey("username")]  
        public int Id { get; set; }

        [Column("username")]
        public string Name { get; set; }

        [Column("password")] 
        public string Password { get; set; }
    }
}
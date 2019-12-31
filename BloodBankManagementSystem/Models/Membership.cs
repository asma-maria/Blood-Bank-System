using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  System.ComponentModel.DataAnnotations;

using  System.ComponentModel;

namespace BloodBankManagementSystem.Models
{
    public partial class Membership
    {

        public int UserId { get; set; }
       
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string Email { get; set; }
    }
}
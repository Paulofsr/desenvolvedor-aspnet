using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PlanBTestProject.Models
{
    public class Skill
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public Skill()
        {
            Users = new HashSet<ApplicationUser>();
        }
    }
}
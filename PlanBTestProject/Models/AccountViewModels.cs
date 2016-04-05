using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Linq;

namespace PlanBTestProject.Models
{

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "A Senha e a Confirmação de Senha não conferem.")]
        public string ConfirmPassword { get; set; }

        public string RoleAdmin { get { return "Administrador"; } }

        [Display(Name = "Tipo")]
        public string Role { get; set; }
    }

    public class RegisterStaffViewModel : RegisterViewModel
    {
        public RegisterStaffViewModel() { }

        public RegisterStaffViewModel(ApplicationUser user)
        {
            UserName = user.UserName;
            Email = user.Email;

        }

        [Required]
        public new string Role { get; set; }

        public SelectList RoleTypes
        {
            get
            {
                return new SelectList(new List<ListItem>()
                                        {
                                            new ListItem("Selecione", ""),
                                            new ListItem("Programador", "Programador"),
                                            new ListItem("Designer", "Designer")
                                        });
            }
        }
    }

    public class SkillUserViewModel
    {
        public ApplicationUser User { get; set; }

        public List<SkillUser> Skills { get; set; }

        public SkillUserViewModel(ApplicationUser user)
        {
            User = user;
            ApplicationDbContext db = new ApplicationDbContext();
            Skills = new List<SkillUser>();
            List<Skill> sks = db.Skills.ToList();
            foreach (Skill skill in sks)
            {
                Skills.Add(new SkillUser()
                            {
                                Skill = skill,
                                Selected = user.Skills.FirstOrDefault(c => c.ID == skill.ID) != null
                            });
            }
        }
    }

    public class SkillUser
    {
        public Skill Skill { get; set; }

        public bool Selected { get; set; }

        public string Checked { get { return Selected ? "checked" : ""; } }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

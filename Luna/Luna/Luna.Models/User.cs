using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Luna.Models
{

    //用户模型
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage="必填")]
        [StringLength(20,MinimumLength=4,ErrorMessage="{1}到{0}个字符")]
        [Display(Name="用户名")]
        public string UserName { get; set; }
      

        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "显示名")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "密码")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        ///<summary>
        ///用户状态
        ///0正常，1锁定，2未通过邮件验证，3未通过管理员
        ///</summary>        
        public int Status { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime RegistrationTime { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime LoginTime { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime LoginIP { get; set; }



    }
}

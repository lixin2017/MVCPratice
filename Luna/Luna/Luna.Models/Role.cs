using System;
using System.ComponentModel.DataAnnotations;


namespace Luna.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required(ErrorMessage="必填")]
        [StringLength(20,MinimumLength=2,ErrorMessage="{1}到{0}个字符")]
        [Display(Name="名称")]
        public string Name { get; set; }

        /// <summary>
        /// 用户类型<br />
        /// 0普通类型（普通注册用户），1特权类型（像VIP之类的类型），3管理类型（管理权限的类型）
        /// </summary>
        [Required(ErrorMessage="必填")]
        [Display(Name="用户类型")]
        public int Type { get; set; }

        [Required(ErrorMessage="必填")]
        [StringLength(50,ErrorMessage="少于{0}个字符")]
        public string Description { get; set; }

        /// <summary>
        /// 获取角色类型名称
        /// </summary>
        /// <returns></returns>
        public string TypeToString()
        {
            switch (Type)
            {
                case 0:
                    return "普通";
                case 1:
                    return "特权";
                case 2:
                    return "管理";
                default:
                    return "未知";
            }
        }
    }
}

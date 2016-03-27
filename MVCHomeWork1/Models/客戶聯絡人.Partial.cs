namespace MVCHomeWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人
    {
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        [EmailAddress(ErrorMessage = "不合規之電子郵件位址")]
        public string Email { get; set; }

        [StringLength(11, ErrorMessage = "手機碼數目不正確")]
        [RegularExpression(@"^?([0-9]{4})?[-]{1}?([0-9]{6})$", ErrorMessage = "請按照手機格式輸入:0900-000000")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        [Required]
        public bool 已刪除 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }

    }
    public partial class 客戶聯絡人 : IValidatableObject
    {
        客戶資料Entities db = new 客戶資料Entities();
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (this.Id == default(int))
            {
                //create code
            }
            else
            {
                //update code
            }
            if (!string.IsNullOrEmpty(this.Email))
            {
                EmailValidation vali = new EmailValidation();
                if(vali.validation(this.Id,this.客戶Id,this.Email))
                    yield return new ValidationResult("已有重覆的Email", new string[] { "Email" });

            }


        }

    }
}

namespace MVCHomeWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶資料MetaData))]
    public partial class 客戶資料
    {
    }
    
    public partial class 客戶資料MetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage="必填欄位")]
        public string 客戶名稱 { get; set; }
        
        [StringLength(8, ErrorMessage="名稱長度不得大於 8 個字元")]
        [Required(ErrorMessage = "必填欄位")]
       
        public string 統一編號 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元！")]
        [Required(ErrorMessage = "必填欄位")]
        [PhoneAttribute]
        public string 電話 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 傳真 { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string 地址 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [EmailAddress(ErrorMessage = "不合規之電子郵件位址")]        
        public string Email { get; set; }
       
        public bool 已刪除 { get; set; }
    
        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
    }

    public partial class 客戶資料 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(this.統一編號))
            { 
                if (this.統一編號.Length !=8 )
                {                                     //錯誤字顯示                       顯示欄位 不給值顯示在該content上方
                    yield return new ValidationResult("必須為八碼", new string[] { "統一編號" });
                }
            }
        }

    }
}

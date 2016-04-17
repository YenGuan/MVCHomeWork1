namespace MVCHomeWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(VW_HomeWorkCount1MetaData))]
    public partial class VW_HomeWorkCount1
    {
    }
    
    public partial class VW_HomeWorkCount1MetaData
    {
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 客戶名稱 { get; set; }
        public Nullable<int> 銀行資訊數量 { get; set; }
        public Nullable<int> 聯絡人數量 { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeddingForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class form
    {
        
        public int Id { get; set; }
        [DisplayName("您的大名:")]
        [Required(ErrorMessage ="必填")]
        public string name { get; set; }
        [DisplayName("男/女 方親友:")]
        [Required(ErrorMessage = "必填")]
        public string camp { get; set; }
        [DisplayName("攜伴數量:")]
        [Required(ErrorMessage = "必填")]
        [Range(1,10,ErrorMessage ="別帶超過10個阿")]
        public string many { get; set; }
        [DisplayName("與新人關係:")]
        [Required(ErrorMessage = "必填")]
        public string relation { get; set; }
        [DisplayName("給新人的話:")]
        [Required(ErrorMessage = "必填")]
        public string wantsay { get; set; }
    }
}

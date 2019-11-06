namespace MVC_Validation.Models2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserTable")]
    //跟上一個的差異：
    //（1）.所有[驗證]規則都被遺除了，放到令一個類別檔裡面（名為UserTable2ItemAttributes）
    //（2）.多了一個[Metadatatype]

    //*****************************************
    [MetadataType(typeof(UserTable2ItemAttributes))]
    //*****************************************
    public partial class UserTable2
    {
        //***驗證規則移到令一個UserTable2Attributes.cs檔案
        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(1)]
        public string UserSex { get; set; }

        public DateTime? UserBirthDay { get; set; }

        [StringLength(15)]
        public string UserMobilePhone { get; set; }
    }
}

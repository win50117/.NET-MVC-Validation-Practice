namespace MVC_Validation.Models2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserTable")]
    //��W�@�Ӫ��t���G
    //�]1�^.�Ҧ�[����]�W�h���Q�򰣤F�A���O�@�����O�ɸ̭��]�W��UserTable2ItemAttributes�^
    //�]2�^.�h�F�@��[Metadatatype]

    //*****************************************
    [MetadataType(typeof(UserTable2ItemAttributes))]
    //*****************************************
    public partial class UserTable2
    {
        //***���ҳW�h����O�@��UserTable2Attributes.cs�ɮ�
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

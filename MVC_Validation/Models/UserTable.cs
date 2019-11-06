namespace MVC_Validation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;   // �C�����W�誺 [ ]�Ÿ��A�N�o�f�t�o�өR�W�Ŷ�
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;   //�f�t [Bind(Include=.......)]  ���R�W�Ŷ�

    [Table("UserTable")]

    // �g�b Model�����O�ɸ̭��A�N���έ��Ʀa�g�b�s�W�B�R���B�ק�C�Ӱʧ@�����C
    // [Bind(Include = "UserId, UserName, UserSex, UserBirthDay, UserMobilePhone")]
    // �i�H�קK overposting attacks �]�L�h�o�G�^����  http://www.cnblogs.com/Erik_Xu/p/5497501.html
    public partial class UserTable
    {
        [Key]    // �D������]P.K.�^
        [Display(Name = "ID�W��(UserName�A����)")]
        public int UserId { get; set; }


        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0}�A�ܤ֭n�� {2} �Ӧr(�̪����\ {1} �Ӧr)")]
        // {0} �� [Display(Name=....)]     
        // {1} �� [StringLength(50,
        // {2} �� [StringLength(...MinimumLength = 3,  .... �H�������C�ЬݹϤ�
        [Display(Name = "�W��(UserName�A����)")]
        [Required(ErrorMessage = "*** �ۭq�T�� *** ������� ***")]     // �������
        public string UserName { get; set; }


        [StringLength(1)]
        [Display(Name = "�ʧO(UserSex)")]
        public string UserSex { get; set; }


        //====================================================================
        [Display(Name = "�ͤ�(UserBirthDay)")]
        [DataType(DataType.Date)]    // �u����� - �u�~���v�C�p�G�O DateTime�N�O�u����P�ɶ��v
        // �[�FDataType�A�Шϥ� Chrome�s�������[��C�|�X�{²�檺�u���v���C

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]   // �]�w����� yyyy/MM/dd �榡

        // *** �]�� jQuery�睊�A�����ܦ������D ***  
        // �]�w����϶��]��/��/�~�^������
        //[Range(typeof(DateTime), "1/1/1950", "1/1/2025" ,ErrorMessage = "����϶��A�u��b1950�~�H��~2025�~���e")]   
        // ��t�d�� https://msdn.microsoft.com/zh-tw/library/system.componentmodel.dataannotations.rangeattribute(v=vs.110).aspx
        // �u����϶��v�����ҡA�L�ġC �Ѫk�p�U https://stackoverflow.com/questions/27182606/asp-mvc-5-client-validation-for-range-of-datetimes

        // *** �ۭq���� Custom Validation �ݩ� ***   
        // �ҥH�� My �}�Y�R�W�C �Ԩ� /Models1Validation�ؿ��U�� MyValidateDateRangeAttribute.cs�ɮ�
        [MyValidateDateRange(MyStartDate = "1/1/1950", MyEndDate = "1/1/2025", ErrorMessage = "����϶��A�u��b1950�~�H��~2025�~���e")]
        public DateTime UserBirthDay { get; set; }
        //====================================================================


        [StringLength(15, ErrorMessage = "*** �ۭq�T�� *** ������X���o�W�L15�ӼƦr ***")]
        [Display(Name = "������X(UserMobilePhone�A����)")]
        [RegularExpression(@"^(09)([0-9]{8})$")]   // �e��ӼƦr�����O09�A�᭱��ۤK�ӼƦr�]�����O0~9���Ʀr�^�C
        // ���W�B��B���W��F�]regular expression�^�C  ^�Ÿ� �N��}�l�A$�Ÿ� �N�����C
        [Required]     // �������
        public string UserMobilePhone { get; set; }


        //=== �ɥR���� =======================================(start)
        //public string Passwd { get; set; }

        //[DataType(DataType.Password)]
        //[Compare("���O�W��.Passwd", ErrorMessage = "���~�T��")]   
        ////// ����ݩʪ��Ȥ��ۤ���A�Ҧp�A��J�K�X��A�A���T�{

        //[System.ComponentModel.DataAnnotations.Compare("Passwd")]
        ////�]���t�@�� System.Web.Mvc�R�W�Ŷ� �]���uCompare�v����r�A���F�קK�x�Z�A�ҥH�n�g�M���C
        //public string PasswdConfirm { get; set; }
        //=== �ɥR���� =======================================(end)
    }
}

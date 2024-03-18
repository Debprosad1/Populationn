using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Population.Models
{
    public class People
    {
        public int Id { get; set; }

        public string Name { get; set; }
        //[Display(Name = "Father Name")]


        public string FatherName { get; set; }
        //[Display(Name = "Mother Name")]

        public string MotherName { get; set; }
        //[Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }

        public int BloodGroupId { get; set; }
        [ForeignKey("BloodGroupId")]
        public virtual BloodGroups BloodGroups { get; set; }

        public int SSCBoardId { get; set; }
        [ForeignKey("SSCBoardId")]
        public virtual SSCBoards SSCBoards { get; set; }

        public int HSCBoardId { get; set; }
        [ForeignKey("HSCBoardId")]
        public virtual HSCBoards HSCBoards { get; set; }
        public string PresentAddress { get; set; }
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }
        [Display(Name = "MobileNo")]
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        [Display(Name = "SSC School name")]
        public string SSCNameOfSchool { get; set; }

        [Display(Name = "SSC Passing Year")]
        public string SSCYearOfPassing { get; set; }
        [Display(Name = "SSC Result")]
        public string SSCResult { get; set; }
        [Display(Name = "HSC College Name")]
        public string HSCNameOfCollege { get; set; }
        [Display(Name = "HSC Board Name")]
        public string HSCNameOfBoard { get; set; }
        [Display(Name = "HSC Passing year")]

        public string HSCYearOfPassing { get; set; }
        [Display(Name = "HSC Result")]

        public string HSCResult { get; set; }
        [Display(Name = "BSC Department")]
        public string BSCDepartment { get; set; }
        public string University { get; set; }
        [Display(Name = "BSC Passing Year")]
        public string BSCYearOfPassing { get; set; }
        [Display(Name = "university/Board")]
        public string universityOrBoard { get; set; }
        [Display(Name = " BSC Result")]
        public string BSCResult { get; set; }
        [Display(Name = "Career Objective")]
        public string CareerObjective { get; set; }
        public string Skill { get; set; }
    }
}

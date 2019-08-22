using MySomething.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySomething.Models
{
    public class UserViewModel
    {
        public UserViewModel()  // new landığında direk oluşsun diye yaptık
        {
            List<SelectListItem> typeList = new List<SelectListItem>();
            SelectListItem typelistItem = new SelectListItem();
            typelistItem.Text = "Admin";
            typelistItem.Value = "0";            
            typeList.Add(typelistItem);

            SelectListItem typelistItem1 = new SelectListItem();
            typelistItem1.Text = "Normal";
            typelistItem1.Value = "1";
            typelistItem1.Selected = true;
            typeList.Add(typelistItem1);

            this.TypeList = typeList;
            this.CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        [MahmutOlmaz]
        [Required]
        public string Name { get; set; }

        [MahmutOlmaz]
        [Required]
        public string Surname { get; set; }

        [Required]
        [MinLength(5)] //en az 5 karakter girilmeli        
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        [DataType(DataType.Password)]
        [MyPassword]
        public string Password { get; set; }
        
        [Range(0,1)] // type sadece 0-1 olmalı
        public int Type { get; set; }

        public DateTime CreateDate { get; set; }

        public string FullName //bu db de olmayacak. Name ile Surname i birleştirip getirecek.
        {
            get { return this.Name + " " + this.Surname; }
        }

        public List<SelectListItem> TypeList
        { get; set; }
    }
}
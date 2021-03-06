﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Extensions;
using Microsoft.AspNetCore.Http;

namespace BugTracker.Models
{
    public class Project
    {

        public Project()
        {
            Members = new HashSet<BTUser>();
            Tickets = new HashSet<Ticket>();
        }

        //Keys
        public int Id { get; set; }

        public int? CompanyId { get; set; }

        //Body
        [Required]
        [StringLength(50)]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Select Image")]
        [NotMapped]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", "doc", "docx", "xls", "xlsx", "pdf" })]
        public IFormFile FormFile { get; set; }

        public string FileName { get; set; }

        public byte[] FileData { get; set; }

        //Navigation
        public virtual ICollection<BTUser> Members { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual Company Company { get; set; }



    }
}

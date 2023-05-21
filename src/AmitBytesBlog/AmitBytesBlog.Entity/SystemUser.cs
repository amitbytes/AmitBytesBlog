using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmitBytesBlog.Entity
{
    public class SystemUser : EntityBase
    {

        public override string Id { get => SystemUserId; set => SystemUserId = value; }

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string SystemUserId { get; set; }
        [Required(ErrorMessage ="Fullname is required")]
        [MaxLength(50,ErrorMessage ="You may have only {1} characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(50, ErrorMessage = "You may have only {1} characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(25,ErrorMessage = "You may have only {1} characters")]
        [MinLength(6,ErrorMessage ="please enter atleast {1} characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Must be a valid email address")]
        [MaxLength(50, ErrorMessage = "You may have only {1} characters")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Title is required")]
        [MaxLength(50, ErrorMessage = "You may have only {1} characters")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Mobile number is required")]
        [MaxLength(12, ErrorMessage = "You may have only {1} characters")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        public bool IsAdmin { get; set; } = false;

    }
}

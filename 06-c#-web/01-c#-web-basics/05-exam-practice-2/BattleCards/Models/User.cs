using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BattleCards.Common;

namespace BattleCards.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public User(string username, string email, string password)
            : this()
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }

        public string Id { get; set; }

        [Required]
        [MinLength(Constants.UsernameMinLength)]
        [MaxLength(Constants.UsernameМaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(Constants.PasswordMinLength)]
        [MaxLength(Constants.PasswordМaxLength)]
        public string Password { get; set; }

        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EthioSpark.Entities.Profile;

namespace EthioSpark.Entities
{
    public class User
    {
        public User()
        {
            Pictures = new HashSet<Picture>();
            PrflAttrValues = new HashSet<PrflAttrValue>();
        }
        [Key]
        public int UserId { get; set; }
        public Guid MembershipUserId { get; set; }
        public byte Gender { get; set; }
        public byte SeekingGender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<PrflAttrValue> PrflAttrValues { get; set; }
    }
}
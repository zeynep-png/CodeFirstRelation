﻿namespace CodeFirstRelation.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public ICollection<PostEntity> Posts { get; set; }
    }
}

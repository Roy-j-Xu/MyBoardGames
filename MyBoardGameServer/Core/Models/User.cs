using System.ComponentModel.DataAnnotations.Schema;

namespace MyBoardGameServer.Core.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("username")]
        public required string Username { get; set; }

    }
}

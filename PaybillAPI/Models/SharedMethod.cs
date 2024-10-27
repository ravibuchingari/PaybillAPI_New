using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace PaybillAPI.Models
{
    public class SharedMethod
    {
        internal static void ThrowError(DbUpdateException ex)
        {
            if (ex.InnerException is MySqlException sqlExp)
            {
                throw sqlExp.Number switch
                {
                    1451 => new Exception(string.Format(AppConstants.SQL_DELETE_REFERENCE_MESSAGE, "item")),
                    1452 => new Exception("Cannot add or update a child row: a foreign key constraint fails"),
                    2627 => new Exception("Unique constraint error"),
                    547 => new Exception("Constraint check violation"),
                    2601 => new Exception("Duplicated key row error/Constraint violation exception"),
                    1062 => new Exception(ex.InnerException.Message.Split("for")[0].Trim()),
                    _ => new Exception(sqlExp.Message),
                };
            }
            throw new Exception(ex.Message);
        }

        public static string GenerateUniqueID() => Guid.NewGuid().ToString("N");
    }
}

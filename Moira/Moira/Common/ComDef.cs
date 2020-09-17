using Moira.JWT;
using Moira.JWT.Models;

namespace Moira.Common
{
    public class ComDef
    {
        // Token Verification
        public static JWTContainerModel jWTContainerModel = new JWTContainerModel();
        public static JWTService jwtService = new JWTService(jWTContainerModel.SecretKey);

        public static readonly string DATA_BASE_URL = $"SERVER=localhost;DATABASE=;UID=root;PASSWORD=;allow user variables=true";

        /// <summary>
        /// Sort data indexes after insert, delete execution
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string GetIndexSortSQL(string tableName, string idxName)
        {
            string sortSql = $@"
ALTER 
    TABLE moira.{tableName} AUTO_INCREMENT = 1;
SET 
    @COUNT = 0;
UPDATE
    moira.{tableName} SET {idxName} = @COUNT:= @COUNT + 1
;";
            return sortSql;
        }
    }
}

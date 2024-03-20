using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace SqlClr.Assemblies
{
    public partial class RegularExpressions
    {
        [SqlFunction(IsDeterministic = true)]
        public static SqlBoolean SqlClrRegexMatch(SqlChars input, SqlString pattern)
        {
            if (input.IsNull || pattern.IsNull)
                return SqlBoolean.Null;

            Regex regex = new Regex(pattern.Value);
            return regex.IsMatch(new string(input.Value));
        }
    }
}
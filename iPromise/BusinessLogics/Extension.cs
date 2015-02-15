using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace iPromise.BusinessLogics
{
    public static class Extension
    {
        public static TResult GetDefaultIfDBNull<TResult>(this IDataRecord dataRecord, string name,
                                                        Func<IDataRecord, string, TResult> expression, TResult @default)
        {
            return dataRecord[name] == DBNull.Value ? @default : expression(dataRecord, name);
        }

        //public static string ErrorInfo(this ErrorInfo[] errorInfos)
        //{
        //    if (errorInfos == null)
        //        return string.Empty;

        //    var html = new StringBuilder();

        //    foreach (var errorInfo in errorInfos)
        //        html.AppendLine(string.Format("Line: {0}. Error: {1}.", errorInfo.LineNumber, errorInfo.ExceptionInfo.Message));

        //    return html.ToString();
        //}

        //public static List<KeyValuePair<string, string>> Append(this List<KeyValuePair<string, string>> source, List<KeyValuePair<string, string>> keyValuePairs)
        //{
        //    if (keyValuePairs == null)
        //        return source;

        //    foreach (var keyValuePair in keyValuePairs)
        //        source.Add(keyValuePair);

        //    return source;
        //}
    }
}
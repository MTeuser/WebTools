// -----------------------------------------------------------------------
// <copyright file="Tools_Functions.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.Linq.Expressions;
    using System.Text.RegularExpressions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Utilities
    {
        public string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return (sb.ToString());
        }

        public string GetCriteria(string predicate)
        {
            string criteria = predicate;
            if (!Regex.Replace(criteria, "['][^']*[']", "").Contains("Active")) {
                criteria = criteria + "AND (Active = 1)";
            }
            return criteria;
        }
    }
}

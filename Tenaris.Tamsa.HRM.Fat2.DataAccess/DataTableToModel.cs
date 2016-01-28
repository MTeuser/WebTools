using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess
{
    public class DataTableToModel
    {
        public static IList<T> DatatableToClass<T>(DataTable Table) where T : class, new()
        {
            //if (!Helper.IsValidDatatable(Table))
            //    return new List<T>();

            Type classType = typeof(T);
            IList<PropertyInfo> propertyList = classType.GetProperties();

            // Parameter class has no public properties.
            if (propertyList.Count == 0)
                return new List<T>();

            List<string> columnNames = Table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToList();

            List<T> result = new List<T>();
            try
            {
                foreach (DataRow row in Table.Rows)
                {
                    T classObject = new T();
                    foreach (PropertyInfo property in propertyList)
                    {
                        if (property == null || !property.CanWrite)   // Make sure property isn't read only
                        {
                            continue;
                        }
                        if (!columnNames.Contains(property.Name))  // If property is a column name
                        {
                            continue;
                        }
                        if (row[property.Name] == System.DBNull.Value)   // Don't copy over DBNull
                        {
                            continue;
                        }
                        object propertyValue = System.Convert.ChangeType(
                                row[property.Name],
                                property.PropertyType
                            );
                        property.SetValue(classObject, propertyValue, null);
                           
                    }
                    result.Add(classObject);
                }
                return result;
            }
            catch(Exception e)
            {
                return new List<T>();
            }
        }
    }
}

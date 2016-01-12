using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tenaris.Library.DbClient;
using System.Reflection;

namespace Tenaris.Tamsa.HRM.Fat2.WebTool.DataAccess
{
   
    public class DataAccess : IDisposable
    {
        private DbClient DbClientInstance = null;
        private bool isdisposed;

        public DataAccess()
        {
            DbClientInstance = new DbClient("DbConnection");
            LoadDatabaseCommands(DbClientInstance);            
        }

        /* ******************************************************************************************************************************************************************************************************************** */
        /// <summary>
        /// Gets StoredProcedure
        /// </summary>
        /// <returns></returns>
        /// Se cargan y obtienen los StoredProcedure que se encuentran en la Clase "StoredProcedure"
        #region De la Clase "StoredProcedure" se cargan en el dblClient los StoredProcedure almacenados en ella.
        internal void LoadDatabaseCommands(DbClient dbClient)
        {
            //Leerlas desde la Clase StoredProcedure
            FieldInfo[] SPFieldsInfo = typeof(StoredProcedures).GetFields();
            foreach (var SPField in SPFieldsInfo)
            {
                dbClient.AddCommand((string)SPField.GetValue(null));
            }
        }
        #endregion



        #region Se Remueven todos los Stored Procedure del dbClient
        internal void RemoveDatabaseCommands(DbClient dbClient)
        {
            //Leerlas desde la Clase StoredProcedure
            FieldInfo[] SPFieldsInfo = typeof(StoredProcedures).GetFields();
            foreach (var SPField in SPFieldsInfo)
            {
                dbClient.RemoveCommand((string)SPField.GetValue(null));
            }
        }
        #endregion


        // <summary>
        /// Implement IDisposable method.
        /// </summary>
        /// <param name="disposedStatus">
        /// Dispose status.
        /// </param>
        protected virtual void Dispose(bool disposedStatus)
        {
            if (!this.isdisposed)
            {
                if (disposedStatus)
                {
                    DbClientInstance.Dispose();
                }

                this.isdisposed = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

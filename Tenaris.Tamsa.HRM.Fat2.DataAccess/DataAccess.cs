using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tenaris.Library.DbClient;
using System.Reflection;
using Tenaris.Tamsa.HRM.Fat2.DataAccess.Models;
using Tenaris.Library.Framework;
using System.Linq.Expressions;
using System.Text.RegularExpressions;


namespace Tenaris.Tamsa.HRM.Fat2.DataAccess
{
   
    public class DataAccess : IDisposable
    {
        private DbClient DbClientInstance = null;
        private Utilities Utility = null;
        private ExpQueryTranslator Translator = null;
        private bool isdisposed;

        public DataAccess()
        {
            DbClientInstance = new DbClient("DbConnection");
            LoadDatabaseCommands(DbClientInstance);
            Utility = new Utilities();
            Translator = new ExpQueryTranslator();
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



        public User Login(string identificacion, string password)
        {
            string pass = Utility.GetMD5(password).ToUpper();
            var user = GetUsers(u => u.Identification == identificacion.ToUpper() && u.Password == pass).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("User no found");
            }
        }

        public List<User> GetUsers() { return GetUsers(null); }
        public List<User> GetUsers(Expression<Func<User, bool>> predicate)
        {
            Tenaris.Library.DbClient.IDbCommand cmd = DbClientInstance.GetCommand(StoredProcedures.GetUsers);
            string QueryCriteria = "";
            if (predicate != null)
            {
                QueryCriteria = Utility.GetCriteria(Translator.Translate(predicate));
            }
                 Dictionary<string, object> cmdParams = new Dictionary<string, object>();
                 cmdParams.Add("@QueryCriteria", QueryCriteria);
            var dtResult = cmd.ExecuteTable(new ReadOnlyDictionary<string, object>(cmdParams));            
            return DataTableToModel.DatatableToClass<User>(dtResult).ToList();
        }       

        public User Create(User user)
        {
           
            return user;
        }

        public List<Tool_Tool> GetTools() { return GetTools(null); }
        public List<Tool_Tool> GetTools(Expression<Func<Tool_Tool, bool>> predicate)
        {
            Tenaris.Library.DbClient.IDbCommand cmd = DbClientInstance.GetCommand(StoredProcedures.GetTools);
            string QueryCriteria = "";
            if (predicate != null)
            {
                QueryCriteria = Utility.GetCriteria(Translator.Translate(predicate));
            }
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            cmdParams.Add("@QueryFilter", QueryCriteria);
            var dtResult = cmd.ExecuteTable(new ReadOnlyDictionary<string, object>(cmdParams));
            return DataTableToModel.DatatableToClass<Tool_Tool>(dtResult).ToList();
        }

        public Tool_Tool Create(Tool_Tool Tooltool)
        {
           
            return Tooltool;
        }

        public Tool_Tool Edit(Tool_Tool Tooltool)
        {
           
            return Tooltool;
        }

        public bool Delete(Tool_Tool Tootool)
        {
           return true;
        }

        public List<Tool_Supplier> GetSuppliers() { return GetSuppliers(null); }
        public List<Tool_Supplier> GetSuppliers(Expression<Func<Tool_Supplier, bool>> predicate)
        {
            Tenaris.Library.DbClient.IDbCommand cmd = DbClientInstance.GetCommand(StoredProcedures.GetSuppliers);
            string QueryCriteria = "";
            if (predicate != null)
            {
                QueryCriteria = Utility.GetCriteria(Translator.Translate(predicate));
            }
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            cmdParams.Add("@QueryCriteria", QueryCriteria);
            var dtResult = cmd.ExecuteTable(new ReadOnlyDictionary<string, object>(cmdParams));
            return DataTableToModel.DatatableToClass<Tool_Supplier>(dtResult).ToList();
        }

        public List<Tool_Property> GetToolProperties() { return GetToolProperties(null); }
        public List<Tool_Property> GetToolProperties(Expression<Func<Tool_Property, bool>> predicate)
        {
            Tenaris.Library.DbClient.IDbCommand cmd = DbClientInstance.GetCommand(StoredProcedures.GetSuppliers);
            string QueryCriteria = "";
            if (predicate != null)
            {
                QueryCriteria = Utility.GetCriteria(Translator.Translate(predicate));
            }
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            cmdParams.Add("@QueryCriteria", QueryCriteria);
            var dtResult = cmd.ExecuteTable(new ReadOnlyDictionary<string, object>(cmdParams));
            return DataTableToModel.DatatableToClass<Tool_Property>(dtResult).ToList();
        }

        public List<Tool_Type> GetToolTypes() { return GetToolTypes(null); }
        public List<Tool_Type> GetToolTypes(Expression<Func<Tool_Type, bool>> predicate)
        {
            Tenaris.Library.DbClient.IDbCommand cmd = DbClientInstance.GetCommand(StoredProcedures.GetSuppliers);
            string QueryCriteria = "";
            if (predicate != null)
            {
                QueryCriteria = Utility.GetCriteria(Translator.Translate(predicate));
            }
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            cmdParams.Add("@QueryCriteria", QueryCriteria);
            var dtResult = cmd.ExecuteTable(new ReadOnlyDictionary<string, object>(cmdParams));
            return DataTableToModel.DatatableToClass<Tool_Type>(dtResult).ToList();
        }

        //--- Get all distint Diameter from all Tool type equs idToolType
        public List<int> GetDiameters(int idToolType)
        {
            List<int> diamet = new List<int>();

            //List<Tool_Property> lstProperties = ausv1Context.Properties.Where(p => p.name.ToUpper().Equals("DIAMETRO")).ToList();
            //if (lstProperties != null)
            //{
            //    diamet = lstProperties.Where(
            //                                c => c.ToolDetails.Where(td => td.Tool.idType == idToolType)
            //                                                      .ToList()
            //                                                      .Count > 0)
            //                           .Select(p => Convert.ToInt32(p.Value)).ToList();
            //}
            return diamet;
        }


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

        public List<Tool_Supplier> GetSuppliersByToolType(string sType)
        {
            throw new NotImplementedException();
        }
    }
}

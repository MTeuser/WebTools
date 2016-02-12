using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tenaris.Library.DbClient;
using System.Reflection;
using Tenaris.Tamsa.HRM.Fat2.DataAccess.Models;
using Tenaris.Library.Framework;
using System.Linq.Expressions;
using System.Data;



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

        private DataTable ExecTable(string StoreProcedureName ,Dictionary<string, object> dparams)
        {
            Tenaris.Library.DbClient.IDbCommand _cmd = DbClientInstance.GetCommand(StoreProcedureName);
            DataTable dtResult = _cmd.ExecuteTable(new ReadOnlyDictionary<string, object>(dparams));             
            return dtResult;
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
            var user = GetUsers(identificacion, password).FirstOrDefault();          
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("User no found");
            }
        }

        /// <summary>
        /// Get an user sending identification and password.
        /// Get all users sending identification=null, and password=null
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers() { return GetUsers(null,null); }
        public List<User> GetUsers(string identification, string password)
        {
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            object uPass = null;
            object uId = null;
            if (String.IsNullOrEmpty(identification))
            {
                uPass = null;
                uId = null;
            }
            else
            {
                uPass = Utility.GetMD5(password);
                uId = identification;
            }
            cmdParams.Add("@pIdentification", uId);
            cmdParams.Add("@pPassword", uPass);                                   
            var dtResult = ExecTable(StoredProcedures.Users_Get, cmdParams);
            List<User> UsersList = new List<User>();
            UsersList= DataTableToModel.DatatableToClass<User>(dtResult).ToList();
            return UsersList;
        }       

        public User Create(User user)
        {            
            return user;
        }


        public List<Tool_Tool> GetTools() { return GetTools(null); }
        public List<Tool_Tool> GetTools(Tool_Tool entity)
        {
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            if (entity == null)
            {
                cmdParams.Add("@pidTool", null);
                cmdParams.Add("@pTag", DBNull.Value);
                cmdParams.Add("@pidSuplier", DBNull.Value);
                cmdParams.Add("@pidUser", DBNull.Value);
                cmdParams.Add("@pInsDateTime", DBNull.Value);
                cmdParams.Add("@pUpdDateTime", DBNull.Value);
                cmdParams.Add("@pActive", 1);
            }
            else
            {
                cmdParams.Add("@pidTool", entity.idTool);
                cmdParams.Add("@pTag", entity.Tag);
                cmdParams.Add("@pidSuplier", entity.idSuplier);
                cmdParams.Add("@pidUser", entity.idUser);
                cmdParams.Add("@pInsDateTime", entity.InsDateTime);
                cmdParams.Add("@pUpdDateTime", entity.UpdDateTime);
                cmdParams.Add("@pActive", entity.Active);
            }             
            var dtResult = ExecTable(StoredProcedures.Tool_Get, cmdParams);
            return DataTableToModel.DatatableToClass<Tool_Tool>(dtResult).ToList();
        }

        public Tool_Tool Create(Tool_Tool entity)
        {
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();            
            cmdParams.Add("@pTag", "-");
            cmdParams.Add("@pidSuplier", DBNull.Value);
            cmdParams.Add("@pIdCatalog", entity.IdCatalog);
            cmdParams.Add("@pidUser", entity.idUser);
            cmdParams.Add("@pInsDateTime", DateTime.Now.ToString());
            cmdParams.Add("@pUpdDateTime", DateTime.Now.ToString());
            cmdParams.Add("@pActive", 1);

            var dtResult = ExecTable(StoredProcedures.Tool_Ins, cmdParams);
            return DataTableToModel.DatatableToClass<Tool_Tool>(dtResult).ToList().FirstOrDefault();
            //return Tooltool;
        }

        public Tool_Tool Edit(Tool_Tool entity)
        {
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            cmdParams.Add("@pidTool", entity.idTool);
            cmdParams.Add("@pTag", entity.Tag);
            cmdParams.Add("@pidSuplier", entity.idSuplier);
            cmdParams.Add("@pidUser", entity.idUser);
            cmdParams.Add("@pInsDateTime", entity.InsDateTime);
            cmdParams.Add("@pUpdDateTime", entity.UpdDateTime);
            cmdParams.Add("@pActive", entity.Active);

            var dtResult = ExecTable(StoredProcedures.Tool_Ins, cmdParams);
            return DataTableToModel.DatatableToClass<Tool_Tool>(dtResult).ToList().FirstOrDefault();           
            //return Tooltool;
        }

        public Tool_ToolDetail Create(Tool_ToolDetail entity)
        {
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            cmdParams.Add("@pidToolDetail", entity.idToolDetail);
            cmdParams.Add("@pidProperty", entity.idProperty);
            cmdParams.Add("@pidTool", entity.idTool);
            cmdParams.Add("@pValue", entity.Value);

            var dtResult = ExecTable(StoredProcedures.ToolDetail_Ins, cmdParams);
            return DataTableToModel.DatatableToClass<Tool_ToolDetail>(dtResult).ToList().FirstOrDefault();
            //return Tooltool;
        }

        public bool Delete(Tool_Tool entity)
        {
            //@pIdTool
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            cmdParams.Add("@pIdTool", entity.idTool);

            var dtResult = ExecTable(StoredProcedures.Tool_Del, cmdParams);
            DataTableToModel.DatatableToClass<Tool_ToolDetail>(dtResult).ToList().FirstOrDefault();
           return true;
        }

        public List<Tool_Supplier> GetSuppliers() { return GetSuppliers(null); }
        public List<Tool_Supplier> GetSuppliers(Tool_Supplier entity)
        {
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            /*   
             *@pidSupplier int = null, 
	          @pCode nchar(10) = null, 
	          @pName nchar(10) = null, 
	          @pActive bit = 1, 
	          @pInsDateTime DateTimeOffset(7) = null, 
	          @pUpdDateTime DateTimeOffset(7) = null 
             */

            cmdParams.Add("@pidSupplier", entity.idSupplier);
            cmdParams.Add("@pCode", entity.idSupplier);
            cmdParams.Add("@pName", entity.idSupplier);
            cmdParams.Add("@pActive", entity.idSupplier);
            cmdParams.Add("@pInsDateTime", entity.idSupplier);
            cmdParams.Add("@pUpdDateTime", entity.idSupplier);
            

            var dtResult = ExecTable(StoredProcedures.Suppliers_Get,cmdParams);

            return DataTableToModel.DatatableToClass<Tool_Supplier>(dtResult).ToList();
        }

        public List<Tool_Property> GetToolProperties() { return GetToolProperties(new Tool_Property { }); }
        public List<Tool_Property> GetToolProperties(Tool_Property entity)
        {
           
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            //idProperty, IdCatalog, IdDatatype, name
            cmdParams.Add("@pidProperty", entity.idProperty);
            cmdParams.Add("@pIdCatalog", entity.IdCatalog);
            cmdParams.Add("@pIdDatatype", entity.IdDatatype);            
            cmdParams.Add("@pname", entity.Name);          

            var dtResult = ExecTable(StoredProcedures.Property_Get, cmdParams);
            return DataTableToModel.DatatableToClass<Tool_Property>(dtResult).ToList();
        }

        public List<Tool_Property> GetPropertiesByCatalogId(int idCatalog)
        {
            List<Tool_Property> ListProperties = GetToolProperties(new Tool_Property { IdCatalog = idCatalog });
            return ListProperties;
        }

        public List<Tool_Type> GetToolTypes() { return GetToolTypes(new Tool_Type { }); }
        public List<Tool_Type> GetToolTypes(Tool_Type entity)
        {
          
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();

            cmdParams.Add("@pidType", entity.idType);
            cmdParams.Add("@pCode", entity.Code);
            cmdParams.Add("@pDescription", entity.Description);
            cmdParams.Add("@pName", entity.Name);
            
            var dtResult = ExecTable(StoredProcedures.Types_Get, cmdParams);
            return DataTableToModel.DatatableToClass<Tool_Type>(dtResult).ToList();
        }

        public List<Tool_Supplier> GetSuppliersByToolType(int idType)
        {
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            cmdParams.Add("@pidType", idType);
            var dtResult = ExecTable(StoredProcedures.Suppliers_GetByToolType, cmdParams);
            return DataTableToModel.DatatableToClass<Tool_Supplier>(dtResult).ToList();
        }

       

        public bool Create(Tool_Property entity)
        {
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();

            cmdParams.Add("@pidProperty", entity.idProperty);
            cmdParams.Add("@pIdCatalog", entity.IdCatalog);
            cmdParams.Add("@pIdDatatype", entity.IdDatatype);            
            cmdParams.Add("@pname", entity.Name);

            var dtResult = ExecTable(StoredProcedures.Property_Ins, cmdParams);
            if (dtResult.Rows.Count <= 0)
            {
                throw new Exception();
            }
            //return DataTableToModel.DatatableToClass<Tool_Property>(dtResult).ToList(); 
            return true;
        }

        public List<Tool_Catalog> GetToolCatalog() { return GetToolCatalog(new Tool_Catalog { }); }
        public List<Tool_Catalog> GetToolCatalog(Tool_Catalog entity)
        {

            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            
                cmdParams.Add("@pIdCatalog", entity.IdCatalog);
                cmdParams.Add("@pIdType", entity.IdType);
                //cmdParams.Add("@pActive", entity.Active);
                cmdParams.Add("@pInsDateTime", entity.InsDateTime);
                cmdParams.Add("@pUpdDateTime", entity.UpdDateTime);
          
          

            var dtResult = ExecTable(StoredProcedures.Catalog_Get, cmdParams);
            return DataTableToModel.DatatableToClass<Tool_Catalog>(dtResult).ToList();
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

        public Tool_ToolDetail Update(Tool_ToolDetail entity)
        {
            Dictionary<string, object> cmdParams = new Dictionary<string, object>();
            cmdParams.Add("@pidToolDetail", entity.idToolDetail);
            cmdParams.Add("@pidProperty", entity.idProperty);
            cmdParams.Add("@pidTool", entity.idTool);
            cmdParams.Add("@pValue", entity.Value);

            var dtResult = ExecTable(StoredProcedures.ToolDetail_Udp, cmdParams);
            return DataTableToModel.DatatableToClass<Tool_ToolDetail>(dtResult).ToList().FirstOrDefault();
        }
    }
}

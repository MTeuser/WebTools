using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Linq.Expressions;


namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.AusV1
{
    public class DataAccess
    {
        private AusV1_Entities1 ausv1Context = null;
        private Tools_Functions Tfn = new Tools_Functions();
       // private DbClient DBClient = new DbClient("AusV1_Entities1");

            public DataAccess()
            {
                ausv1Context = new AusV1_Entities1();
            }

        public User Login(string identificacion, string password)
        {
            string pass = Tfn.GetMD5(password).ToUpper();
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
            if (predicate != null)
            {
                var preComp = predicate.Compile();
                predicate = o => preComp(o) && o.Active == true;
                return ausv1Context.Users.Where(predicate.Compile()).ToList();
            }
            return ausv1Context.Users.Where(o => o.Active == true).ToList();
        }

        public User Create(User user)
        {
            ausv1Context.Users.AddObject(user);
            ausv1Context.SaveChanges();
            return user;
        }

        public List<Tool> GetTools() { return GetTools(null); }
        public List<Tool> GetTools(Expression<Func<Tool, bool>> predicate)
        {
            if(predicate != null)
            {
              var preComp =  predicate.Compile();
              predicate = o => preComp(o) && o.Active == true;
              return ausv1Context.Tools.Where(predicate.Compile()).ToList();
            }            
            return ausv1Context.Tools.Where(o => o.Active == true).ToList();
        }

        public Tool Create(Tool Tooltool)
        {
            ausv1Context.Tools.AddObject(Tooltool);          
            ausv1Context.SaveChanges();
            return Tooltool;
        }

        public Tool Edit(Tool Tooltool)
        {
            ausv1Context.Tools.Attach(Tooltool);
            ausv1Context.ObjectStateManager.ChangeObjectState(Tooltool, EntityState.Modified);
            ausv1Context.SaveChanges();
            return Tooltool;
        }

        public bool Delete(Tool Tootool)
        {
            ausv1Context.Tools.DeleteObject(Tootool);
            ausv1Context.SaveChanges();
            return true;
        }

        public List<Supplier> GetSuppliers() { return GetSuppliers(null); }
        public List<Supplier> GetSuppliers(Expression<Func<Supplier, bool>> predicate)
        {
            if (predicate != null)
            {
                var preComp = predicate.Compile();
                predicate = o => preComp(o) && o.Active == true;
                return ausv1Context.Suppliers.Where(predicate.Compile()).ToList();
            }  
            return ausv1Context.Suppliers.Where(o => o.Active == true).ToList();
        }

        public List<Property> GetToolProperties() { return GetToolProperties(null); }
        public List<Property> GetToolProperties(Expression<Func<Property,bool>> predicate)
        {
            if (predicate != null)
            {
                var preComp = predicate.Compile();
                //predicate = o => preComp(o) && o.Active == true;
                return ausv1Context.Properties.Where(preComp).ToList();
            }  
            return ausv1Context.Properties.ToList();
        }

        public List<Type> GetToolTypes() { return GetToolTypes(null); }
        public List<Type> GetToolTypes(Expression<Func<Type, bool>> predicate)
        {
            if (predicate != null)
            {
                var preComp = predicate.Compile();
                //predicate = o => preComp(o) && o.Active == true;
                return ausv1Context.Types.Where(preComp).ToList();
            } 
            return ausv1Context.Types.ToList();
        }

        //--- Get all distint Diameter from all Tool type equs idToolType
        public List<int> GetDiameters(int idToolType)
        {
            List<int> diamet = new List<int>();

            List<Property> lstProperties = ausv1Context.Properties.Where(p => p.name.ToUpper().Equals("DIAMETRO")).ToList();
            if(lstProperties != null)
            {
                diamet = lstProperties.Where(
                                            c => c.ToolDetails.Where(td => td.Tool.idType == idToolType)
                                                                  .ToList()
                                                                  .Count > 0)
                                       .Select(p => Convert.ToInt32(p.Value)).ToList();
            }
            return diamet;
        }

      

        public bool Dispose()
        {
            ausv1Context.Dispose();
            return true;
        }
       
          
    }
}

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

        public List<Tool_Tool> GetTools() { return GetTools(null); }
        public List<Tool_Tool> GetTools(Expression<Func<Tool_Tool, bool>> predicate)
        {
            if(predicate != null)
            {
              var preComp =  predicate.Compile();
              predicate = o => preComp(o) && o.Active == true;
              return ausv1Context.Tool_Tool.Where(predicate.Compile()).ToList();
            }            
            return ausv1Context.Tool_Tool.Where(o => o.Active == true).ToList();
        }

        public Tool_Tool Create(Tool_Tool Tooltool)
        {
            ausv1Context.Tool_Tool.AddObject(Tooltool);
            ausv1Context.SaveChanges();
            return Tooltool;
        }

        public Tool_Tool Edit(Tool_Tool Tooltool)
        {
            ausv1Context.Tool_Tool.Attach(Tooltool);
            ausv1Context.ObjectStateManager.ChangeObjectState(Tooltool, EntityState.Modified);
            ausv1Context.SaveChanges();
            return Tooltool;
        }

        public bool Delete(Tool_Tool Tootool)
        {
            ausv1Context.Tool_Tool.DeleteObject(Tootool);
            ausv1Context.SaveChanges();
            return true;
        }

        public List<Tool_Supplier> GetSuppliers() { return GetSuppliers(null); }
        public List<Tool_Supplier> GetSuppliers(Expression<Func<Tool_Supplier, bool>> predicate)
        {
            if (predicate != null)
            {
                var preComp = predicate.Compile();
                predicate = o => preComp(o) && o.Active == true;
                return ausv1Context.Tool_Supplier.Where(predicate.Compile()).ToList();
            }  
            return ausv1Context.Tool_Supplier.Where(o => o.Active == true).ToList();
        }

        public List<Tool_Property> GetToolProperties() { return GetToolProperties(null); }
        public List<Tool_Property> GetToolProperties(Expression<Func<Tool_Property,bool>> predicate)
        {
            if (predicate != null)
            {
                var preComp = predicate.Compile();
                //predicate = o => preComp(o) && o.Active == true;
                return ausv1Context.Tool_Property.Where(preComp).ToList();
            }  
            return ausv1Context.Tool_Property.ToList();
        }

        public List<Tool_Type> GetToolTypes() { return GetToolTypes(null); }
        public List<Tool_Type> GetToolTypes(Expression<Func<Tool_Type, bool>> predicate)
        {
            if (predicate != null)
            {
                var preComp = predicate.Compile();
                //predicate = o => preComp(o) && o.Active == true;
                return ausv1Context.Tool_Type.Where(preComp).ToList();
            } 
            return ausv1Context.Tool_Type.ToList();
        }

        //--- Get all distint Diameter from all Tool type equs idToolType
        public List<int> GetDiameters(int idToolType)
        {
            List<int> diamet = new List<int>();

            List<Tool_Property> lstProperties = ausv1Context.Tool_Property.Where(p => p.name.ToUpper().Equals("DIAMETRO")).ToList();
            if(lstProperties != null)
            {
                diamet = lstProperties.Where(
                                            c => c.Tool_ToolDetail.Where(td => td.Tool_Tool.idType == idToolType)
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

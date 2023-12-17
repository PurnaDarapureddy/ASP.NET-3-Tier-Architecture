using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using dal;
using bo;

namespace bll
{
   public class user
    {
        dal.user du = new dal.user();
        bo.user bu = new bo.user();
        public DataSet getstate()
        {
            DataSet gs = du.getstate();
            return gs;
        }
        public DataSet getcity(string state)
        {
            DataSet gc = du.getcity(state);
            return gc;
        }
        public int adduser(bo.user v)
        {
            int i = du.adduser(v);
            return i;
        }
        public int Delete(bo.user v)
        {
            int i = du.Delete(v);
            return i;
        }
        public DataSet GetData()
        {
            DataSet ds = du.GetData();
            return ds;
        }
        public int Update(bo.user v)
        {
            int i = du.Update(v);
            return i;
        }
    }
}

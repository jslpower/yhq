using System;
using System.Collections.Generic;
using System.Text;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.BLL
{
    public class Bpersner
    {
        private readonly Eyousoft_yhq.SQLServerDAL.persner dal = new Eyousoft_yhq.SQLServerDAL.persner();
        public int Add(OrderPassenger model)
        {
            return dal.Add(model);
        }



        public IList<OrderPassenger> GetModelList(string ordercode, int PageSize, int PageIndex, ref int RecordCount)
        {
            if (string.IsNullOrEmpty(ordercode)) return null;
            return dal.GetModelList(ordercode, PageSize, PageIndex, ref RecordCount);
        }

    }
}

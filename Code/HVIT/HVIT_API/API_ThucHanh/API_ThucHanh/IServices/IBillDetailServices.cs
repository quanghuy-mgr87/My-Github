using API_ThucHanh.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ThucHanh.IServices
{
    interface IBillDetailServices
    {
        public IEnumerable<BillDetail> GetBillDetailList(string keyword = "");
        public BillDetail CreateNewBillDetail(BillDetail billDetail);
        public BillDetail DeleteBillDetail(int billDetailId);
        public BillDetail UpdateBillDetail(BillDetail billDetail);
    }
}

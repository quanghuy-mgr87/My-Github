using API_ThucHanh.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ThucHanh.IServices
{
    interface IBillServices
    {
        public IEnumerable<Bill> GetBillList(string keyword = "");
        public Bill GetBillById(int billId);
        public Bill CreateNewBill(Bill bill);
        public Bill UpdateBill(Bill bill);
        public Bill DeleteBill(int billId);
    }
}

using API_ThucHanh.Entities;
using API_ThucHanh.Helper;
using API_ThucHanh.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ThucHanh.Services
{
    public class BillServices : IBillServices
    {
        private AppDbContext dbContext { get; }
        private BillDetailServices billDetailServices { get; }

        public BillServices()
        {
            dbContext = new AppDbContext();
            billDetailServices = new BillDetailServices();
        }

        /// <summary>
        /// Create new bill
        /// </summary>
        /// <param name="bill">Object bill</param>
        /// <returns>Object bill</returns>
        public Bill CreateNewBill(Bill bill)
        {
            var currentBill = dbContext.bills.SingleOrDefault(x => x.id == bill.id);
            if (currentBill == null)
            {
                bill.tradingCode = InputHelper.CreateTradingCode();
                bill.createTime = DateTime.Now;
                var BillDetailsList = bill.BillDetails;
                bill.BillDetails = null;
                dbContext.bills.Add(bill);
                dbContext.SaveChanges();
                foreach (var val in BillDetailsList)
                {
                    val.billId = bill.id;
                    if (billDetailServices.CreateNewBillDetail(val) == null)
                        throw new Exception($"Product {val.productId} is not exist!");
                }
                bill.totalPrice = BillDetailsList.Sum(x => x.totalPrice);
                dbContext.bills.Update(bill);
                dbContext.SaveChanges();
            }
            return currentBill;
        }
        /// <summary>
        /// Delete bill
        /// </summary>
        /// <param name="billId">bill id that you want to delete</param>
        /// <returns></returns>
        public Bill DeleteBill(int billId)
        {
            var currentBill = dbContext.bills.SingleOrDefault(x => x.id == billId);
            var getBillDetailsList = dbContext.billDetails.Where(x => x.billId == billId);
            if (currentBill != null)
            {
                //delete bill details list
                getBillDetailsList.ToList().ForEach(x =>
                {
                    dbContext.billDetails.Remove(x);
                    dbContext.SaveChanges();
                });
                dbContext.bills.Remove(currentBill);
                dbContext.SaveChanges();
            }
            return currentBill;
        }
        /// <summary>
        /// Get bill list
        /// </summary>
        /// <param name="keyword">keyword</param>
        /// <returns>bill list</returns>
        public IEnumerable<Bill> GetBillList(string keyword = "")
        {
            var lstBill = dbContext.bills.Include(x => x.BillDetails).AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower().Trim();
                lstBill = lstBill.Where(x => x.billName.ToLower().Contains(keyword));
            }
            return lstBill;
        }
        /// <summary>
        /// Update bill
        /// </summary>
        /// <param name="bill">Object bill that you want to update</param>
        /// <returns></returns>
        public Bill UpdateBill(Bill bill)
        {
            var currentBill = dbContext.bills.SingleOrDefault(x => x.id == bill.id);
            if (currentBill != null)
            {
                currentBill.customerId = bill.customerId;
                currentBill.billName = bill.billName;
                currentBill.tradingCode = bill.tradingCode;
                currentBill.createTime = bill.createTime;
                currentBill.updateTime = bill.updateTime;
                currentBill.note = bill.note;
                //Get bill list with bill id
                var lstBill = dbContext.billDetails.Where(x => x.billId == bill.id);
                currentBill.totalPrice = lstBill.Sum(x => x.totalPrice);
            }
            return currentBill;
        }
        /// <summary>
        /// Get bill by id
        /// </summary>
        /// <param name="billId">billId</param>
        /// <returns>bill</returns>
        public Bill GetBillById(int billId)
        {
            return dbContext.bills.SingleOrDefault(x => x.id == billId);
        }
    }
}

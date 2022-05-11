using API_ThucHanh.Entities;
using API_ThucHanh.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ThucHanh.Services
{
    public class BillDetailServices : IBillDetailServices
    {
        private AppDbContext dbContext { get; }
        public BillDetailServices()
        {
            dbContext = new AppDbContext();
        }

        /// <summary>
        /// Create new bill detail
        /// </summary>
        /// <param name="billDetail">new bill detail</param>
        /// <returns>bill detail have been found if exists and null if none exists</returns>
        public BillDetail CreateNewBillDetail(BillDetail billDetail)
        {
            //Check for product existence in the product list
            if (dbContext.products.Any(x => x.id == billDetail.productId))
            {
                //Find the product to know its price
                var product = dbContext.products.Find(billDetail.productId);

                //Calculate the total price
                billDetail.totalPrice = billDetail.numberOfProduct * product.price;
                dbContext.billDetails.Add(billDetail);
                dbContext.SaveChanges();
                return billDetail;
            }
            else
            {
                var bill = dbContext.bills.Find(billDetail.billId);
                dbContext.bills.Remove(bill);
                dbContext.SaveChanges();
                return null;
            }
        }
        /// <summary>
        /// Delete bill detail
        /// </summary>
        /// <param name="billDetailId">bill detail id</param>
        /// <returns>bill detail have been found if exists and null if none exists</returns>
        public BillDetail DeleteBillDetail(int billDetailId)
        {
            var currentBillDetail = dbContext.billDetails.SingleOrDefault(x => x.id == billDetailId);
            if (currentBillDetail != null)
            {
                dbContext.billDetails.Remove(currentBillDetail);
                dbContext.SaveChanges();
            }
            return currentBillDetail;
        }
        /// <summary>
        /// Get bill details list (by billId) 
        /// </summary>
        /// <param name="keyword">this keyword is billId</param>
        /// <returns>bill details list</returns>
        public IEnumerable<BillDetail> GetBillDetailList(string keyword = "")
        {
            var lstBillDetail = dbContext.billDetails.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                lstBillDetail = lstBillDetail.Where(x => x.billId == int.Parse(keyword));
            }
            return lstBillDetail;
        }
        /// <summary>
        /// Update bill detail
        /// </summary>
        /// <param name="billDetail">object bill detail</param>
        /// <returns>current bill detail if exists or null if none exists</returns>
        public BillDetail UpdateBillDetail(BillDetail billDetail)
        {
            var currentBillDetail = dbContext.billDetails.SingleOrDefault(x => x.id == billDetail.id);
            //get product with productId of current bill detail
            var currentProduct = dbContext.products.Find(billDetail.productId);
            if (currentBillDetail != null && currentProduct != null)
            {
                currentBillDetail.billId = billDetail.billId;
                currentBillDetail.productId = billDetail.productId;
                currentBillDetail.numberOfProduct = billDetail.numberOfProduct;
                currentBillDetail.unit = billDetail.unit;
                currentBillDetail.totalPrice = currentProduct.price * currentBillDetail.numberOfProduct;
                dbContext.billDetails.Update(currentBillDetail);
                dbContext.SaveChanges();
            }
            if (currentProduct == null)
                return null;
            return currentBillDetail;
        }
    }
}

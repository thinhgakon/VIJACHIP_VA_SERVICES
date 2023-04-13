using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHTD_SERVICES.Data.Entities;
using XHTD_SERVICES.Data.Models.Response;
using XHTD_SERVICES.Data.Models.Values;
using XHTD_SERVICES.Data.Common;

namespace XHTD_SERVICES.Data.Repositories
{
    public partial class StoreOrderOperatingRepository
    {
        public async Task<bool> CreateAsync(OrderItemResponse websaleOrder)
        {
            bool isSynced = false;

            var syncTime = DateTime.Now.ToString();

            try
            {
                var vehicleCode = websaleOrder.VehicleId.Replace("-", "").Replace("  ", "").Replace(" ", "").Replace("/", "").Replace(".", "").ToUpper();

                var itemCode = websaleOrder.ItemCode;
                var productItem = _appDbContext.tblItems.FirstOrDefault(x => x.Code == itemCode);
                var productId = productItem?.ItemId ?? null;

                if (CheckExist(websaleOrder.Id))
                {
                    var newOrderOperating = new tblStoreOrderOperating
                    {
                        OrderId = websaleOrder.Id,
                        PartnerId = websaleOrder.DistributorId.ToString(),
                        NameDistributor = websaleOrder.DistributorName,
                        OrderDate = websaleOrder.OrderDate,
                        NameProduct = websaleOrder.ItemName,
                        ItemId = productId,
                        ItemUnitName = websaleOrder.ItemUnitName,
                        SumNumber = (decimal)websaleOrder.NumberOrder,
                        Vehicle = vehicleCode,
                        DriverName = websaleOrder.DriverName,
                        Step = (int)OrderStep.CHUA_XAC_NHAN,
                        Type = websaleOrder.Type,
                        IsVoiced = false,
                        LogProcessOrder = $@"#Sync Tạo đơn lúc {syncTime}",
                        LogJobAttach = $@"#Sync Tạo đơn lúc {syncTime}",
                        RealRequireNumber = (decimal)websaleOrder.NumberOrder,
                        ItemCode = websaleOrder.ItemCode,
                        Note = websaleOrder.Note,
                    };

                    _appDbContext.tblStoreOrderOperatings.Add(newOrderOperating);
                    await _appDbContext.SaveChangesAsync();

                    Console.WriteLine($@"Inserted order {websaleOrder.Id}");
                    log.Info($@"Inserted order {websaleOrder.Id}");

                    isSynced = true;
                }
                else
                {
                    Console.WriteLine($@"Da dong bo {websaleOrder.Id}");
                    log.Info($@"Da dong bo {websaleOrder.Id}");
                }

                return isSynced;
            }
            catch (Exception ex)
            {
                log.Error("=========================== CreateAsync Error: " + ex.Message + " ========== " + ex.StackTrace + " === " + ex.InnerException); ;
                Console.WriteLine("CreateAsync Error: " + ex.Message);

                return isSynced;
            }
        }

        public async Task<bool> CancelOrder(int? orderId)
        {
            bool isSynced = false;

            try
            {
                string syncTime = DateTime.Now.ToString();

                var order = _appDbContext.tblStoreOrderOperatings.FirstOrDefault(x => x.OrderId == orderId && x.IsVoiced != true && x.Step < (int)OrderStep.DA_HOAN_THANH);
                if (order != null)
                {
                    order.IsVoiced = true;
                    order.LogJobAttach = $@"{order.LogJobAttach} #Sync Hủy đơn lúc {syncTime} ";
                    order.LogProcessOrder = $@"{order.LogProcessOrder} #Sync Hủy đơn lúc {syncTime} ";

                    await _appDbContext.SaveChangesAsync();

                    Console.WriteLine($@"Cancel Order {orderId}");
                    log.Info($@"Cancel Order {orderId}");

                    isSynced = true;
                }

                return isSynced;
            }
            catch (Exception ex)
            {
                log.Error($@"=========================== Cancel Order {orderId} Error: " + ex.Message);
                Console.WriteLine($@"Cancel Order {orderId} Error: " + ex.Message);

                return isSynced;
            }
        }
    }
}

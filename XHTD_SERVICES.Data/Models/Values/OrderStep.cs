using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XHTD_SERVICES.Data.Models.Values
{
    public enum OrderStep
    {
        [Display(Name = "Chưa xác nhận")]
        CHUA_XAC_NHAN = 0,

        [Display(Name = "Đã xác nhận")]
        DA_XAC_NHAN = 1,

        [Display(Name = "Đã nhận đơn")]
        DA_NHAN_DON = 2,

        [Display(Name = "Đã vào cổng")]
        DA_VAO_CONG = 3,

        [Display(Name = "Đã cân vào")]
        DA_CAN_VAO = 4,

        [Display(Name = "Đang gọi xe")]
        DANG_GOI_XE = 5,

        [Display(Name = "Đang lấy hàng")]
        DANG_LAY_HANG = 6,

        [Display(Name = "Đã lấy hàng")]
        DA_LAY_HANG = 7,

        [Display(Name = "Đã cân ra")]
        DA_CAN_RA = 8,

        [Display(Name = "Đã hoàn thành")]
        DA_HOAN_THANH = 9,

        [Display(Name = "Đã giao hàng")]
        DA_GIAO_HANG = 10,
    }
}

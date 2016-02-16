using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAl;
using Model;
using System;

namespace BLL
{
    public class ProductOrder_BLL
    {
        private ProductOrder_DAL productDal = new ProductOrder_DAL();

        public bool UpdateInfoByOrderId(ProductOrderInfo info)
        {
            return (this.productDal.UpdateInfoByOrderId(info) > 0);
        }
    }

    public class UserInfo_BLL
    {
        private UserInfo_DAL userinfoDal = new UserInfo_DAL();

        public UserInfo CheckUserInfoByUserNameAndPassword(UserInfo info)
        {
            return this.userinfoDal.CheckUserInfoByUserNameAndPassword(info);
        }
    }
}

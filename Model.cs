using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Model
/// </summary>
public class Model
{
	public Model()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   


    public class AdminInfo
    {
        private int adminID;
        private string adminName;
        private string email;
        private string password;
        private string realName;

        public int AdminID
        {
            get
            {
                return this.adminID;
            }
            set
            {
                this.adminID = value;
            }
        }

        public string AdminName
        {
            get
            {
                return this.adminName;
            }
            set
            {
                this.adminName = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string RealName
        {
            get
            {
                return this.realName;
            }
            set
            {
                this.realName = value;
            }
        }
    }

    public class CategoryInfo
    {
        private int categoryID;
        private string categoryName;

        public int CategoryID
        {
            get
            {
                return this.categoryID;
            }
            set
            {
                this.categoryID = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }
            set
            {
                this.categoryName = value;
            }
        }
    }

    public class ColourInfo
    {
        private int colourID;
        private string name;

        public int ColourID
        {
            get
            {
                return this.colourID;
            }
            set
            {
                this.colourID = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }

    public class OrderDetailInfo
    {
        private int detailID;
        private double hatsFee;
        private int number;
        private int orderID;
        private int productID;

        public int DetailID
        {
            get
            {
                return this.detailID;
            }
            set
            {
                this.detailID = value;
            }
        }

        public double HatsFee
        {
            get
            {
                return this.hatsFee;
            }
            set
            {
                this.hatsFee = value;
            }
        }

        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }

        public int OrderID
        {
            get
            {
                return this.orderID;
            }
            set
            {
                this.orderID = value;
            }
        }

        public int ProductID
        {
            get
            {
                return this.productID;
            }
            set
            {
                this.productID = value;
            }
        }
    }

    public class ProductOrderInfo
    {
        private int amount;
        private double gstFee;
        private double hatsFee;
        private bool isSend;
        private DateTime orderDate;
        private int orderID;
        private string receiverAddress;
        private string receiverEmail;
        private string receiverName;
        private string receiverPhone;
        private string receiverPostCode;
        private double totalPrice;

        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public double GstFee
        {
            get
            {
                return this.gstFee;
            }
            set
            {
                this.gstFee = value;
            }
        }

        public double HatsFee
        {
            get
            {
                return this.hatsFee;
            }
            set
            {
                this.hatsFee = value;
            }
        }

        public bool IsSend
        {
            get
            {
                return this.isSend;
            }
            set
            {
                this.isSend = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return this.orderDate;
            }
            set
            {
                this.orderDate = value;
            }
        }

        public int OrderID
        {
            get
            {
                return this.orderID;
            }
            set
            {
                this.orderID = value;
            }
        }

        public string ReceiverAddress
        {
            get
            {
                return this.receiverAddress;
            }
            set
            {
                this.receiverAddress = value;
            }
        }

        public string ReceiverEmail
        {
            get
            {
                return this.receiverEmail;
            }
            set
            {
                this.receiverEmail = value;
            }
        }

        public string ReceiverName
        {
            get
            {
                return this.receiverName;
            }
            set
            {
                this.receiverName = value;
            }
        }

        public string ReceiverPhone
        {
            get
            {
                return this.receiverPhone;
            }
            set
            {
                this.receiverPhone = value;
            }
        }

        public string ReceiverPostCode
        {
            get
            {
                return this.receiverPostCode;
            }
            set
            {
                this.receiverPostCode = value;
            }
        }

        public double TotalPrice
        {
            get
            {
                return this.totalPrice;
            }
            set
            {
                this.totalPrice = value;
            }
        }
    }

    public class ProductsInfo
    {
        private string description;
        private string hatName;
        private double price;
        private int productID;

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public string HatName
        {
            get
            {
                return this.hatName;
            }
            set
            {
                this.hatName = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public int ProductID
        {
            get
            {
                return this.productID;
            }
            set
            {
                this.productID = value;
            }
        }
    }

    public class SupplierInfo
    {
        private string email;
        private string homePhone;
        private string mobile;
        private int supplierID;
        private string supplierName;
        private string workPhone;

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public string HomePhone
        {
            get
            {
                return this.homePhone;
            }
            set
            {
                this.homePhone = value;
            }
        }

        public string Mobile
        {
            get
            {
                return this.mobile;
            }
            set
            {
                this.mobile = value;
            }
        }

        public int SupplierID
        {
            get
            {
                return this.supplierID;
            }
            set
            {
                this.supplierID = value;
            }
        }

        public string SupplierName
        {
            get
            {
                return this.supplierName;
            }
            set
            {
                this.supplierName = value;
            }
        }

        public string WorkPhone
        {
            get
            {
                return this.workPhone;
            }
            set
            {
                this.workPhone = value;
            }
        }
    }

    public class SysdiagramsInfo
    {
        private byte[] definition;
        private int diagram_id;
        private string name;
        private int principal_id;
        private int version;

        public byte[] Definition
        {
            get
            {
                return this.definition;
            }
            set
            {
                this.definition = value;
            }
        }

        public int Diagram_id
        {
            get
            {
                return this.diagram_id;
            }
            set
            {
                this.diagram_id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Principal_id
        {
            get
            {
                return this.principal_id;
            }
            set
            {
                this.principal_id = value;
            }
        }

        public int Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }
    }

    public class UserInfo
    {
        private string address;
        private string email;
        private string firstName;
        private string homePhone;
        private string lastName;
        private string mobile;
        private int orderID;
        private string password;
        private int userID;
        private string userName;
        private string workPhone;

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string HomePhone
        {
            get
            {
                return this.homePhone;
            }
            set
            {
                this.homePhone = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public string Mobile
        {
            get
            {
                return this.mobile;
            }
            set
            {
                this.mobile = value;
            }
        }

        public int OrderID
        {
            get
            {
                return this.orderID;
            }
            set
            {
                this.orderID = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public int UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        public string WorkPhone
        {
            get
            {
                return this.workPhone;
            }
            set
            {
                this.workPhone = value;
            }
        }
    }
}



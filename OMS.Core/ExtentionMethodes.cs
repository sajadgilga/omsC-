using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OMS.Core
{
    public static class ExtentionMethodes
    {
        public static string ToJsonString(this object obj)
        {
            string retVal = null;
            if (obj != null)
            {
                retVal = new JavaScriptSerializer().Serialize(obj);
            }
            return retVal;
        }
        public static NscState ToNseState(this string obj)
        {
            NscState retVal = NscState.NotProvided;
            switch (obj)
            {
                case "I ":
                    {
                        retVal = NscState.Forbidden;
                        break;
                    }
                case "IG":
                    {
                        retVal = NscState.ForbiddenFrozen;
                        break;
                    }
                case "IS":
                    {
                        retVal = NscState.ForbiddenSuspended;
                        break;
                    }
                case "IR":
                    {
                        retVal = NscState.ForbiddenReserved;
                        break;
                    }
                case "A ":
                    {
                        retVal = NscState.Authorized;
                        break;
                    }
                case "AG":
                    {
                        retVal = NscState.AuthorizedFrozen;
                        break;
                    }
                case "AS":
                    {
                        retVal = NscState.AuthorizedSuspended;
                        break;
                    }
                case "AR":
                    {
                        retVal = NscState.AuthorizedReserved;
                        break;
                    }
            }
            return retVal;
        }

        public static OrderLockType ToOrderLockType(this byte data)
        {
            return (OrderLockType)Enum.ToObject(typeof(OrderLockType), data);
        }

        public static OrderSource ToOrderSource( this byte data)
        {
            return (OrderSource)Enum.ToObject(typeof(OrderSource), data);
        }

        public static OrderStatus ToOrderStatus(this byte data)
        {
            return (OrderStatus)Enum.ToObject(typeof(OrderStatus), data);
        }

        public static OrderValidity ToOrderValidity(this byte data)
        {
            return (OrderValidity)Enum.ToObject(typeof(OrderValidity), data);
        }

        public static OrderSide ToOrderSide(this byte data)
        {
            return (OrderSide)Enum.ToObject(typeof(OrderSide), data);
        }

        public static OrderCreditSource ToOrderCreditSource(this byte data)
        {
            return (OrderCreditSource)Enum.ToObject(typeof(OrderCreditSource), data);
        }
    }
}

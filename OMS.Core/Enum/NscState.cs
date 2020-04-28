using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public enum NscState
    {
        NotProvided = 1,
        /// <summary>
        /// مجاز - A
        /// </summary>
        Authorized,
        /// <summary>
        /// مجاز-مسدود - AG
        /// </summary>
        AuthorizedFrozen,
        /// <summary>
        /// مجاز-متوقف - AS
        /// </summary>
        AuthorizedSuspended,
        /// <summary>
        /// مجاز-محفوظ = AR
        /// </summary>
        AuthorizedReserved,
        /// <summary>
        /// ممنوع - I
        /// </summary>
        Forbidden,
        /// <summary>
        /// ممنوع-مسدود - IG
        /// </summary>
        ForbiddenFrozen,
        /// <summary>
        /// ممنوع-متوقف - IS
        /// </summary>
        ForbiddenSuspended,
        /// <summary>
        /// ممنوع-محفوظ = IR
        /// </summary>
        ForbiddenReserved,
        /// <summary>
        /// ممنوع - I
        /// </summary>


    }
}

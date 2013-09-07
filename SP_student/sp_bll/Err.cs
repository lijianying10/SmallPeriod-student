using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sp_bll
{
    /// <summary>
    /// this class for return value
    /// show the status of the function running status.
    /// </summary>
    public class Err
    {
        /// <summary>
        /// constructure function
        /// initial this object by default value
        /// </summary>
        public Err()
        {
            this.res = true;
            this.info = "All operation success";
        }

        /// <summary>
        /// status of result
        /// </summary>
        public bool res { get; set; }

        /// <summary>
        /// status information
        /// </summary>
        public string info { get; set; }
    }
}

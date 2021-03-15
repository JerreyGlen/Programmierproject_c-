using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserPointer
{
    public class LaserPointerInfo : Interfaces.LaserPointerInfo
    {
        public double xPercentage
        {
            get;
            set;
        }

        public double yPercentage
        {
            get;
            set;
        }
        /// <summary>
        /// parameterless constructor for deserialization
        /// </summary>
        public LaserPointerInfo()
        {

        }

        /// <summary>
        /// constructor for the laserpointerinfoclass
        /// </summary>
        /// <param name="topPercentage">distance to the top border of window divided by height of window</param>
        /// <param name="leftPercentage">distance to the left border of window divided by width of window</param>
        public LaserPointerInfo(double xpercentage, double ypercentage)
        {
            this.yPercentage = ypercentage;
            this.xPercentage = xpercentage;
        }
    }
}

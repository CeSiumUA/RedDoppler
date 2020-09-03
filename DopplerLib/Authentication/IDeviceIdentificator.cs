using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DopplerLib.Authentication
{
    public interface IDeviceIdentificator
    {
        string GetDeviceIdentificator();
    }
}

using Shopy.Common.Interfaces;
using System;

namespace Shopy.Infrastructure.Common
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Exeptions
{
    public class BussinesExceptions:Exception
    {
        public BussinesExceptions()
        {

        }
        public BussinesExceptions(string message) : base(message)
        {


        }
    }
}

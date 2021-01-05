using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class ExceptionDeletingCarriage : Exception
    {
        public ExceptionDeletingCarriage() : base("Cannot be deleted because there are purchased seats in the car")
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolfTracker.Web.Api.Models
{
    public class ApiShot
    {
        public int SequenceNumber
        {
            get;
            set;
        }

        public int PlayerId
        {
            get;
            set;
        }

        public int HoleId
        {
            get;
            set;
        }

        public int Attempts
        {
            get;
            set;
        }

        public bool ShotMade
        {
            get;
            set;
        }
    }
}

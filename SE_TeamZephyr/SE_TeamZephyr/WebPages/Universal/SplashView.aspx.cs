using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace SE_TeamZephyr
{
    public partial class _Default : Page
    {

        private Autom8DBAppContext11 _db = new Autom8DBAppContext11();
        private IdentityDBContext _db1 = new IdentityDBContext();

        protected void Page_Load(object sender, EventArgs e)
        {



        }

        private string DataRetreival()
        {



            return "test";
        }

    }
}
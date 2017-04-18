using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Vote.DAO;

namespace Vote.Controllers
{
    public class ApiBaseController : ApiController
    {
        internal VoteEF db = new VoteEF();

    }
}
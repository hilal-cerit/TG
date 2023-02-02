using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using TgWorkshop.WebAPI.Models;
using TgWorkshop.WebAPI.Repository;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using ServiceStack;
using System.Web.Helpers;

namespace TgWorkshop.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
      
        public IProductRepository _productRepository;
       

        public IndexModel(ILogger<IndexModel> logger, IProductRepository productRepository)
        {
          _productRepository= productRepository;
            _logger = logger;
        }
     

       
      public void OnGet()
        {

        }

      



    } 
   
}
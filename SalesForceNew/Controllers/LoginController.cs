using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceNew.Models;
using SalesForceNew.Class;


namespace SalesForceNew.Controllers
{
    public class LoginController : ApiController
    {
        public LoginClass Get(string Username, String password)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                var entity = entities.UserDetails().FirstOrDefault(d => d.Username == Username);

                if (entity == null)
                {
                    LoginClass response = new LoginClass();
                    response.Id = 0;
                    response.FirstName = null;
                    response.LastName = null;

                    response.UserType = null;
                    response.status = "No Username";
                    response.Image = null;
                    response.Token = null;
                    return response;

                }
                else
                {

                    if (entity.Passwords == password)
                    {
                        LoginClass response = new LoginClass();
                        response.Id = entity.Id;
                        response.FirstName = entity.FirstName;
                        response.LastName = entity.LastName;
                        response.Email = entity.Email;
                        response.UserType = entity.UserType;
                        response.status = "Success";
                        response.Image = entity.Image;

                        string txt = Username + ':' + password;
                       
                        var txtBytes = System.Text.Encoding.UTF8.GetBytes(txt);
                        string token= System.Convert.ToBase64String(txtBytes);


                        response.Token = token;                       
                        return response;

                    }


                    else
                    {
                        LoginClass response = new LoginClass();
                        response.Id = 0;
                        response.FirstName = null;
                        response.LastName = null;
                        response.UserType = null;
                        response.status = "Fail";
                        response.Image = null;
                        response.Token = null;
                        return response;
                    }

                }
            }
        }
    }
}

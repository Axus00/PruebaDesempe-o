using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using Veterinaria.Models;
using Veterinaria.Dto;

namespace Veterinaria.Controllers.Mail
{
    public class MailController
    {
        public async void EmailSend(Owner owner, Pet pet)
        {
            try
            {
                string url = "https://api.mailersend.com/v1/email";
                string AuthToken = "mlsn.8b2536b0d00a573489f0eb333ff843771ccdbe23352ca27bee7a1d7eef3c5848";
                var EmailMessage = new Email
                {
                    From = new From { Email = "info@trial-0r83ql3omdvlzwlj.mlsender.net" },
                    To = new[]
                    {
                        new To { Email = owner.Email }
                    },
                    subject = "Quote vet",
                    text = $"Sr owner your quote is the next with the pet {pet.Name}",
                    html = $"Sr owner your quote is the next with the pet {pet.Name}",
                };

                string JsonBody = JsonSerializer.Serialize(EmailMessage);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("ContentType", "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AuthToken}");
                    StringContent content = new StringContent(JsonBody, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    //We verify the correct action of function
                    if(response.IsSuccessStatusCode)
                    {
                        string ResponseBody = await response.Content.ReadAsStringAsync();
                        System.Console.WriteLine("Response of server: ");
                        System.Console.WriteLine(ResponseBody);
                    }
                    else
                    {
                        System.Console.WriteLine($"The request fail with the error: {response.StatusCode}");
                    }
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        internal void EmailSend()
        {
        }
    }
}
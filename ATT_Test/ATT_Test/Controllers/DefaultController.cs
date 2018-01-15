using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Octokit;
using ATT_Test.Models;
using System.Threading.Tasks;

namespace ATT_Test.Controllers
{
    public class DefaultController : ApiController
    {
        private List<Issues> test;

        public DefaultController(List<Issues> test)
        {
            this.test = test;
        }

        public async Task<IHttpActionResult> Get()
        {

            try
            {
                //Utilized octokit.net client Libary for authentication and retriveing repository from github.
                GitHubClient client = new GitHubClient(new ProductHeaderValue("Att"));
                //Implimeted basic authentication for accessing gitHub to avoid ratelimit issue.
                Credentials basicAuth = new Credentials("rajamanduri1989@gmail.com", "Ra5a7252");
                client.Credentials = basicAuth;
                var apiInfo = client.GetLastApiInfo();
                var rateLimit = apiInfo?.RateLimit;
                var howManyRequestsCanIMakePerHour = rateLimit?.Limit;
                var howManyRequestsDoIHaveLeft = rateLimit?.Remaining;
                var whenDoesTheLimitReset = rateLimit?.Reset;

                List<string> repo = new List<string>();
                List<Issues> Issues_list = new List<Issues>();
                // Getting all public repositories for att public domain.
                var rep = await client.Repository.GetAllForOrg("Att");
                foreach (var re in rep)
                {
                    repo.Add(re.Name);

                }
                if (repo != null)
                {

                    foreach (var val in repo)
                    {   
                        //Getting all issuess and related commnets for each att public repository.
                        var iss = await client.Issue.GetAllForRepository("att", val.ToString());
                        foreach (var item in iss)
                        {
                            Issues_list.Add(new Issues
                            {
                                title = item.Title,
                                Body = item.Body,
                                Comments = item.Comments,
                                Commentsurl = item.CommentsUrl,
                                url = item.Url,

                            });
                        }
                    }
                    //The List itesms are serlized in to Json. used Newton json package.
                    var json = JsonConvert.SerializeObject(Issues_list);
                    return Ok(json);
                }
                else
                {
                    return Content(System.Net.HttpStatusCode.NotFound, "No Repository found");
                }

            }
            catch (Exception e)
            {

                return Content(System.Net.HttpStatusCode.ExpectationFailed, e);
            }
        }
    }
}

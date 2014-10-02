namespace BullsAndCows.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BullsAndCows.Data;
    using BullsAndCows.Services.DataModels;

    public class ScoresController : BaseApiController
    {
        public ScoresController(IBullsAndCowsData data) : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var users = this.Data.Users.All().OrderBy(u => u.Rank).Select(UserRankDataModel.FromUser).ToList();

            return this.Ok(users);
        }
    }
}
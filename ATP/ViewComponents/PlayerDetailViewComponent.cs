using ATP.DataAccess.API;
using Microsoft.AspNetCore.Mvc;

namespace ATP.ViewComponents
{
    public class PlayerDetailViewComponent : ViewComponent
    {
        PlayerDetail _playerDetail;
        public PlayerDetailViewComponent(PlayerDetail playerDetail)
        {
            _playerDetail = playerDetail;
        }
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            Data playerDetail;
            if (Id != null)
            {
                var responseTask = _playerDetail.GetPlayerDetail(Id);
                responseTask.Wait();
                playerDetail = responseTask.Result;
            }
            else
            {
                playerDetail = new Data();
            }
            return View(playerDetail);
        }
    }
}

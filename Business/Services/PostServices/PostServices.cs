using Data.Models.ResultModel;
using Data.Repositories.PostRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.PostServices
{
    public class PostServices : IPostServices
    {
        private readonly IPostRepo _postRepo;

        public PostServices(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }
        public async Task<ResultModel> GetPostById(Guid id)
        {
            ResultModel result = new();
            try
            {
                var post = _postRepo.GetPostById(id);
                if (post == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Not found";
                    result.Code = 200;
                    return result;
                }
                result.IsSuccess = true;
                result.Data = post;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Code = 400;
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }
            return result;
        }
    }
}
